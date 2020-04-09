using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vshope.Application.Common.Abstr;
using Vshope.Db;
using Vshope.Db.Common;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Dict;

namespace Vshope.Application.Common
{
    public class DictService : IDictService
    {
        private readonly ContextApp _context;
        private readonly IMapper _mapper;

        public DictService(ContextApp context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListResultDTO<ProductTypeDTO>> GetProductTypeDict()
        {
           
            var items = await _context.ProductTypes
                .WhereIsNotDeleted()
                .Select(x => new ProductTypeDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
            var total = items.Count;
            var result = new ListResultDTO<ProductTypeDTO>(items, total);
            return result;
        }

        public async Task<ListResultDTO<ProductCategoryDTO>> GetProductCategoryDict(int productTypeId)
        {
            var items = await _context.ProductCategories
                .WhereIsNotDeleted(x=> x.TypeId == productTypeId)
                .Select(x => new ProductCategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
            var total = items.Count;
            var result = new ListResultDTO<ProductCategoryDTO>(items, total);
            return result;
        }

        public async Task<ListResultDTO<ProductGoodsTypeDTO>> GetProductGoodsTypeDict(int productCategoryId)
        {
            var items = await _context.ProductGoodsTypes
                .WhereIsNotDeleted(x => x.CategoryId == productCategoryId)
                .Select(x => new ProductGoodsTypeDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
            var total = items.Count;
            var result = new ListResultDTO<ProductGoodsTypeDTO>(items, total);
            return result;
        }

        public async Task<ListResultDTO<ProductApparelDTO>> GetProductApparelDict(int productGoodsTypeId)
        {
            var items = await _context.ProductApparels
                .WhereIsNotDeleted(x => x.GoodsTypeId == productGoodsTypeId)
                .Select(x => new ProductApparelDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
            var total = items.Count;
            var result = new ListResultDTO<ProductApparelDTO>(items, total);
            return result;
        }

        public async Task<ListResultDTO<ProductSizeDTO>> GetProductSizeDict(int productGoodsTypeId, int? productApparelId)
        {
            var items = new List<ProductSizeDTO>();
            if (productApparelId.HasValue)
            {
                items = await _context.ProductSizes
                    .WhereIsNotDeleted(x => x.GoodsTypeId == productGoodsTypeId
                                       && x.ApparelId == productApparelId)
                    .Select(x => new ProductSizeDTO
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToListAsync();
            }

            if (items.Count == 0)
            {
                items = await _context.ProductSizes
                    .WhereIsNotDeleted(x => x.GoodsTypeId == productGoodsTypeId
                                       && !x.ApparelId.HasValue)
                    .Select(x => new ProductSizeDTO
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToListAsync();
            }

            var total = items.Count;
            var result = new ListResultDTO<ProductSizeDTO>(items, total);
            return result;
        }

        public async Task<ListResultDTO<ProductAdTypeDTO>> GetProductAdTypeDict()
        {
            var items = await _context.ProductAdTypes
                .WhereIsNotDeleted()
                .Select(x => new ProductAdTypeDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
            var total = items.Count;
            var result = new ListResultDTO<ProductAdTypeDTO>(items, total);
            return result;
        }

        public async Task<ListResultDTO<ProductConditionDTO>> GetProductConditionDict()
        {
            var items = await _context.ProductConditions
                .WhereIsNotDeleted()
                .Select(x => new ProductConditionDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
            var total = items.Count;
            var result = new ListResultDTO<ProductConditionDTO>(items, total);
            return result;
        }
    }
}
