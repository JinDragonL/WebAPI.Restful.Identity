using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIRestfulIdentity.DataAccess.Model
{
    public class UserClaim : IdentityUserClaim<int>
    {
    }
}
