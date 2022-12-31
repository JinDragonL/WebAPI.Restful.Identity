using Microsoft.AspNetCore.Identity;

namespace WebAPIRestfulIdentity.DataAccess.Model
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
