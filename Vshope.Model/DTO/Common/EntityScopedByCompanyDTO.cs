using System;
using Vshope.Model.DTO.Main;

namespace Vshope.Model.DTO.Common
{
    public class EntityScopedByCompanyDTO: EntityAppDTO
    {
        public int CompanyId { get; set; }
        public CompanyDTO Company { get; set; }
    }
}
