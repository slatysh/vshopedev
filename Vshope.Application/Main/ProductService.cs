using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VkNet;
using VkNet.Model;
using Vshope.Application.Extension;
using Vshope.Application.Main.Abstr;
using Vshope.Common.Exception;
using Vshope.Db;
using Vshope.Db.Common;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Main;
using Vshope.Model.Model.Main;

namespace Vshope.Application.Main
{
    public class ProductService: IProductService
    {
        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        readonly IVkService _vkService;
        readonly IAvitoXmlService _avito;

        public ProductService(ContextApp context, IMapper mapper, IVkService vkService)
        {
            _context = context;
            _mapper = mapper;
            _vkService = vkService;
        }

        public async Task<ListResultDTO<ProductListInfoDTO>> GetProductList(ListRequestDTO listRequestDTO,
            int companyId)
        {
            var query = _context.Products.WhereIsNotDeleted();
            var total = await query.CountAsync();
            var items = await query.ApplyListRequestFilter(listRequestDTO, OrderKeySelectorFromString)
                .ProjectTo<ProductListInfoDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            var result =
                new ListResultDTO<ProductListInfoDTO>(items, total);
            return result;
        }

        public async Task GetAndSaveProductListFromVk(int companyId, string vkToken)
        {
            var count = await _vkService.GetAndSaveProductList(companyId, vkToken);
        }

        public async Task<int> GetProductCountFromVk(int companyId, string vkToken)
        {
            var company = await _context.Companies.Where(x => x.Id == companyId).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
            }
            var count = await _vkService.GetProductCountFromVk(companyId, vkToken);
            return count;
        }

        private Expression<Func<Product, object>> OrderKeySelectorFromString(string key)
        {
            switch (key)
            {
                case "itemVkId":
                    return x => x.VkId;
                case "itemName":
                    return x => x.Name;
                case "itemDescription":
                    return x => x.Description;
                case "itemPrice":
                    return x => x.Price;
                default: throw new BusinessLogicException(ExceptionCodes.BL_CODE_ORDER_BY_KEY_NOT_DEFINED);
            }
        }
    }
}
