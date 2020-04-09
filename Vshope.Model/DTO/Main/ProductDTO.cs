using System;
using System.Collections.Generic;
using System.Text;
using Vshope.Model.DTO.Common;

namespace Vshope.Model.DTO.Main
{
    public class ProductDTO: EntityScopedByCompanyDTO
    {
        public long VkId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? Price { get; set; }
        public List<long> ImageIds { get; set; }
    }
}
