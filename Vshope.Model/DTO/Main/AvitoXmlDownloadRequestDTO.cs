using System;
using System.Collections.Generic;
using System.Text;
using Vshope.Model.DTO.Common;

namespace Vshope.Model.DTO.Main
{
    public class AvitoXmlDownloadRequestDTO
    {
        public string DateStart { get; set; }
        public string DateFinish { get; set; }

        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }

        public int ProductTypeId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductGoodsTypeId { get; set; }
        public int ProductApparelId { get; set; }
        public int ProductAdTypeId { get; set; }
        public int ProductSizeId { get; set; }
        public int ProductConditionId { get; set; }

        public string ProductAdditionalDesc { get; set; }
    }
}
