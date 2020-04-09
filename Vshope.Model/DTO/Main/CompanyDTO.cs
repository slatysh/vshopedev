using System.Collections.Generic;
using Vshope.Model.DTO.Common;
using Vshope.Model.Model.Common;
using Vshope.Model.Model.Main;

namespace Vshope.Model.DTO.Main
{
    public class CompanyDTO: EntityAppDTO
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
        public int? ProductCategoryId { get; set; }
        public int? ProductGoodsTypeId { get; set; }
        public int? ProductApparelId { get; set; }
        public int? ProductAdTypeId { get; set; }
        public int? ProductSizeId { get; set; }
        public int? ProductConditionId { get; set; }

        public string ProductAdditionalDesc { get; set; }
    }
}
