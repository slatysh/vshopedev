using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using Vshope.Application.Main.Abstr;
using Vshope.Application.Util.Abstr;
using Vshope.Common;
using Vshope.Common.Exception;
using Vshope.Db;
using Vshope.Db.Common;
using Vshope.Model.DTO.Main;
using Vshope.Model.Model.Main;

namespace Vshope.Application.Main
{
    public class VkService : IVkService
    {
        readonly ContextApp _context;
        readonly IMapper _mapper;
        private readonly ILogger _logger;
        readonly VkApi _vkApi;
        readonly IConfiguration _conf;
        readonly IWebRequestService _webRequestService;

        public VkService(IConfiguration conf, ContextApp context, ILogger<VkService> logger, IMapper mapper, IWebRequestService webRequestService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _conf = conf;
            _vkApi = new VkApi();
            _webRequestService = webRequestService;
        }

        public async Task<string> GetAccessToken(string code, string redirectUri)
        {
            string str = _webRequestService.GetRequest(ConstantsApp.VK_API_OAUTH_HOST, ConstantsApp.VK_API_OAUTH_TOKEN_ENDPOINT + $"?client_id={_conf["VkApi:AppId"]}&client_secret={_conf["VkApi:ClientSecret"]}&v={ConstantsApp.VK_API_VERSION}&code={code}&redirect_uri={redirectUri}");
            dynamic stuff = JsonConvert.DeserializeObject(str);
            string token = stuff.access_token;
            return token;
        }

        public async Task<int> GetAndSaveProductList(int companyId, string vkToken)
        {
            _vkApi.Authorize(new ApiAuthParams()
            {
                ApplicationId = ulong.Parse(_conf["VkApi:AppId"]),
                Settings = Settings.All,
                AccessToken = vkToken
            });
            var company = await _context.Companies.Where(x => x.Id == companyId).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
            }
            if (!company.VkId.HasValue)
            {
                throw new BusinessLogicException(ExceptionCodes.VK_ID_INVALID);
            }
            var count = 0;
            var offset = 0;
            var oldProductIdList = await _context.Products.WhereIsNotDeleted(x=> x.CompanyId == companyId).Select(x => x.VkId).ToListAsync();
            var products = await _vkApi.Markets.GetAsync(-1 * company.VkId.Value, null,
                ConstantsApp.VK_API_MARKET_GET_PRODUCT_PER_STEP, offset, true);
                    
            //while (products.Count > 0 && offset< ConstantsApp.VK_API_MARKET_GET_PRODUCT_MAX_COUNT)
            //{
            count += products.Count;
            foreach (var product in products)
            {
                if (product.Id.HasValue)
                {
                    var productVkId = (long) product.Id;
                    var productNew = new Product()
                    {
                        Name = product.Title,
                        Description = product.Description,
                        VkId = productVkId,
                        Price = product.Price.Amount / 100,
                        CompanyId = company.Id
                    };
                    var alreadyExistProductNew = await _context.Products.Where(x => x.VkId == productVkId)
                        .FirstOrDefaultAsync();
                    if (alreadyExistProductNew != null)
                    {
                        _context.SetValuesApp(alreadyExistProductNew, productNew);
                        productNew = alreadyExistProductNew;
                    }
                    else
                    {
                        await _context.Products.AddAsync(productNew);
                    }

                    var oldProductIdListInd = oldProductIdList.FindIndex(x => x == productVkId);
                    if (oldProductIdListInd >= 0)
                    {
                        oldProductIdList.RemoveAt(oldProductIdListInd);
                    }
                    foreach (var photo in product.Photos)
                    {
                        if (photo.Id.HasValue)
                        {
                            var photoVkId = (long) photo.Id;
                            var vkImage = new VkImage()
                            {
                                VkId = photoVkId,
                                Url = photo.Sizes.Where(x => x.Type == PhotoSizeType.Y)
                                    .Select(x => x.Url.AbsoluteUri).FirstOrDefault(),
                                ProductId = productNew.Id
                            };
                            var alreadyExistVkImage = await _context.VkImages.Where(x => x.VkId == photoVkId)
                                .FirstOrDefaultAsync();
                            if (alreadyExistVkImage != null)
                            {
                                _context.SetValuesApp(alreadyExistVkImage, vkImage);
                            }
                            else
                            {
                                await _context.VkImages.AddAsync(vkImage);
                            }
                        }
                        else
                        {
                            _logger.LogCritical(LoggerEventCodes.VK_API_MARKET_GET_PRODUCT_PHOTO_NO_VK_ID,
                                $"Vk api get no vk id for photo, url={photo.PhotoSrc.AbsoluteUri}");
                        }
                    }
                }
                else
                {
                    _logger.LogCritical(LoggerEventCodes.VK_API_MARKET_GET_PRODUCT_NO_VK_ID,
                        $"Vk api get no vk id for product, name={product.Title}");
                }
            }

            offset += ConstantsApp.VK_API_MARKET_GET_PRODUCT_PER_STEP;
            //products = await _vkApi.Markets.GetAsync(-1 * group.Id, null, ConstantsApp.VK_API_MARKET_GET_PRODUCT_PER_STEP, offset);
            //}
            foreach (var oldProductId in oldProductIdList)
            {
                var oldProduct = await _context.Products.Where(x=> x.VkId == oldProductId).Include(x=> x.Images).FirstAsync();
                foreach (var image in oldProduct.Images)
                {
                    image.IsDeleted = true;
                }
                oldProduct.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
            return count;
        }

        public async Task<long?> GetCompanyIdFromVk(string vkStr, string vkToken)
        {
            try
            {

                _vkApi.Authorize(new ApiAuthParams()
                {
                    ApplicationId = ulong.Parse(_conf["VkApi:AppId"]),
                    Settings = Settings.All,
                    AccessToken = vkToken
                });
            }
            catch (Exception e)
            {
                throw new BusinessLogicException(ExceptionCodes.VK_AUTH_TOKEN_INCORRECT);
            }

            long? vkId = null;
            if (!string.IsNullOrEmpty(vkStr))
            {
                try
                {
                    var group = (await _vkApi.Groups.GetByIdAsync(null, vkStr, GroupsFields.All)).FirstOrDefault();
                    vkId = group?.Id;
                }
                catch (ParameterMissingOrInvalidException e)
                {
                }
            }
            return vkId;
        }

        public async Task<int> GetProductCountFromVk(int companyId, string vkToken)
        {
            try
            {

                _vkApi.Authorize(new ApiAuthParams()
                {
                    ApplicationId = ulong.Parse(_conf["VkApi:AppId"]),
                    Settings = Settings.All,
                    AccessToken = vkToken
                });
            }
            catch (Exception e)
            {
                throw new BusinessLogicException(ExceptionCodes.VK_AUTH_TOKEN_INCORRECT);
            }

            var company = await _context.Companies.Where(x => x.Id == companyId).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
            }
            if (!company.VkId.HasValue)
            {
                throw new BusinessLogicException(ExceptionCodes.VK_ID_INVALID);
            }
            var count = 0;
            var productsData = await _vkApi.Markets.GetAsync(-1 * company.VkId.Value, null, 0, 0);
            if (productsData.TotalCount > ConstantsApp.VK_API_MARKET_GET_PRODUCT_MAX_COUNT)
            {
                count = ConstantsApp.VK_API_MARKET_GET_PRODUCT_MAX_COUNT;
            }
            else
            {
                count = (int)productsData.TotalCount;
            }
            return count;
        }
    }
}
