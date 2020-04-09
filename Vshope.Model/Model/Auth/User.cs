using System;
using Vshope.Model.Model.Common;
using Vshope.Model.Model.Dict;
using Vshope.Model.Model.Main;

namespace Vshope.Model.Model.Auth
{
    public class User : EntityApp
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? StatusId { get; set; }
        public UserStatus Status { get; set; }
    }
}
