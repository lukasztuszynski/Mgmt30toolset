using System;
using System.ComponentModel.DataAnnotations;

namespace Mgmt30toolset.Web.ViewModel
{
    public class KudoViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Receiver")]
        public int ReceiverId { get; set; }

        [Display(Name = "Sender")]
        public int SenderId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Last update")]
        public DateTime DateUpdated { get; set; }
    }
}
