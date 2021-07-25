using Microsoft.AspNetCore.Identity;

namespace samsung.sedac.alligatormanagerproject.Api.Entities
{
    public class UserRole:IdentityUserRole<int>
    {
        public Users Users { get; set; }
        public Role Role { get; set; }

       
    }
}
