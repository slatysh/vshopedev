using System;
using Vshope.Model.Model.Main;

namespace Vshope.Model.Model.Common
{
    public class EntityScopedByCompany: EntityApp
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
