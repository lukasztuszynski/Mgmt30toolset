using System.ComponentModel.DataAnnotations;

namespace Mgmt30toolset.Models
{
    public class Kudo : ModelObject
    {
        [Display(Name = "Content")]
        public string Content { get; set; }
        
        [Display(Name = "Receiver")]
        public virtual User Receiver { get; set; }

        [Display(Name = "Sender")]
        public virtual User Sender { get; set; }

        [Display(Name = "Category")]
        public virtual KudoCategory Category { get; set; }
    }
}
