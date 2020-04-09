using System;

namespace Vshope.Model.DTO.Common
{
    public class EntityAppDTO
    {
        public int? Id { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
