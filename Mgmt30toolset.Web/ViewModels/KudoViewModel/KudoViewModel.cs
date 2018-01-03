using System;
using System.ComponentModel.DataAnnotations;
using Mgmt30toolset.Model;

namespace Mgmt30toolset.Web.ViewModel
{
    public class KudoViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Receiver")]
        public string ReceiverId { get; set; }
        [Required]
        [Display(Name = "Sender")]
        public User Sender { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Last update")]
        public DateTime DateUpdated { get; set; }
    }
}
