using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mgmt30toolset.Models.ViewModels
{
    public class KudoEditViewModel
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

        public KudoEditViewModel()
        {

        }

        public KudoEditViewModel(Kudo kudo)
        {
            Id = kudo.Id;
            Content = kudo.Content;
            SenderId = kudo.Sender.Id;
            ReceiverId = kudo.Receiver.Id;
            CategoryId = kudo.Category.Id;
            DateUpdated = kudo.DateUpdated;
        }
    }
}
