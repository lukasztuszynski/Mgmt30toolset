using Mgmt30toolset.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mgmt30toolset.Web.ViewModel
{
    public class KudoFormViewModel
    {
        public KudoViewModel KudoViewModel { get; set; }
        private IEnumerable<KudoCategory> categories;
        private IEnumerable<User> users;

        public KudoFormViewModel() { }
        public KudoFormViewModel(IEnumerable<KudoCategory> categories, IEnumerable<User> users)
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
                Selected = u.Id == KudoViewModel?.ReceiverId
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
                Selected = c.Id == KudoViewModel?.CategoryId
            });
        }

        public void SetCategories(IEnumerable<KudoCategory> categories)
        {
            this.categories = categories;
        }
    }
}
