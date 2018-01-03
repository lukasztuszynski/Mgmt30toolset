using System.ComponentModel.DataAnnotations;

namespace Mgmt30toolset.Model
{
    public class EduPoint : ModelObject
    {
        [Display(Name = "Receiver")]
        public virtual User Receiver { get; set; }

        [Display(Name = "Sender")]
        public virtual User Sender { get; set; }

        [Display(Name = "Category")]
        public virtual EduPointCategory Category { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
