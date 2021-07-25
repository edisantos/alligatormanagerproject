using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace samsung.sedac.alligatormanagerproject.Api.Entities
{
    public class Users:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartamentoId { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
