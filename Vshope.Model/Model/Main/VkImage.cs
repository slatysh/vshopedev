using System;
using System.Collections.Generic;
using System.Text;
using Vshope.Model.Model.Common;

namespace Vshope.Model.Model.Main
{
    public class VkImage: EntityApp
    {
        public long VkId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; }
    }
}
