using System.ComponentModel.DataAnnotations;

namespace Mgmt30toolset.Web.ViewModel
{
    public class LoginFormViewModel
    {
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
