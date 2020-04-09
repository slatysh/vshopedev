using System;
using System.Collections.Generic;
using System.Text;
using Vshope.Model.Model.Common;
using Vshope.Model.Model.Dict;

namespace Vshope.Model.Model.Main
{
    public class Company: EntityApp
    {
        public string VkStr { get; set; }
        public long? VkId { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int? ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int? ProductGoodsTypeId { get; set; }
        public ProductGoodsType ProductGoodsType { get; set; }
        public int? ProductApparelId { get; set; }
        public ProductApparel ProductApparel { get; set; }
        public int? ProductAdTypeId { get; set; }
        public ProductAdType ProductAdType { get; set; }
        public int? ProductSizeId { get; set; }
        public ProductSize ProductSize { get; set; }
        public int? ProductConditionId { get; set; }
        public ProductCondition ProductCondition { get; set; }

        public string ProductAdditionalDesc { get; set; }
    }
}
