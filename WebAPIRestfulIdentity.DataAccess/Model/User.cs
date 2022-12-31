using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIRestfulIdentity.DataAccess.Model
{
    public class User: IdentityUser<int>
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
