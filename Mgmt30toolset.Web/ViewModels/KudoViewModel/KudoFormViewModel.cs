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
       public KudoViewModel KudoViewModel {get;set;} 
       public IEnumerable<KudoCategory> Categories {get;set;}
       public IEnumerable<User> Users {get;set;}

       public IEnumerable<SelectListItem> GetSenders()
       {
           return Users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}".Trim(),
                Selected = u.Id == KudoViewModel?.SenderId
            });
       }

       public IEnumerable<SelectListItem> GetReceivers()
       {
           return Users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}".Trim(),
                Selected = u.Id == KudoViewModel?.ReceiverId
            });
       }

       public IEnumerable<SelectListItem> GetCategories()
       {
           return Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = c.Id == KudoViewModel?.CategoryId
            });
       }
    }
}
