using System;
using System.Collections.Generic;
using System.Text;
using Vshope.Model.DTO.Common;

namespace Vshope.Model.DTO.Main
{
    public class VkImageDTO: EntityAppDTO
    {
        public long VkId { get; set; }
        public string Url { get; set; }
    }
}
