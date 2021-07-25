using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace samsung.sedac.alligatormanagerproject.Api.Entities
{
    public class Role:IdentityRole<int>
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
