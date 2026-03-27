using Microsoft.AspNetCore.Identity;

namespace SmartBank_AuthService.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
    }
}
