using Mgmt30toolset.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mgmt30toolset.Web.ViewModel
{
    public class EduPointTransferFormViewModel
    {
        public EduPointViewModel EduPointViewModel { get; set; }
        private IEnumerable<EduPointCategory> categories;
        private IEnumerable<User> users;

        public EduPointTransferFormViewModel() { }
        public EduPointTransferFormViewModel(IEnumerable<EduPointCategory> categories, IEnumerable<User> users)
        {
            this.categories = categories;
            this.users = users;
        }
        public IEnumerable<SelectListItem> GetReceivers()
        {
            return users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}".Trim(),
                Selected = u.Id == EduPointViewModel?.ReceiverId
            });
        }

        public void SetUsers(IEnumerable<User> users)
        {
            this.users = users;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = c.Id == EduPointViewModel?.CategoryId
            });
        }

        public void SetCategories(IEnumerable<EduPointCategory> categories)
        {
            this.categories = categories;
        }
    }
}
