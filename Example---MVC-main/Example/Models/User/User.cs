using Microsoft.AspNetCore.Identity;

namespace Example.Models.User
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
