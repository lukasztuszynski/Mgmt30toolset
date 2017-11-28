using Microsoft.AspNetCore.Identity;

namespace Mgmt30toolset.Model
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
