using System;
using System.Collections.Generic;
using System.Text;
using Vshope.Model.Model.Common;

namespace Vshope.Model.Model.Main
{
    public class Product: EntityScopedByCompany
    {
        public long VkId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? Price { get; set; }
        public List <VkImage> Images { get; set; }
    }
}
