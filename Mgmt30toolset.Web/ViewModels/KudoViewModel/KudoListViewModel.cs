using Mgmt30toolset.Model;
using System.Collections.Generic;

namespace Mgmt30toolset.Web.ViewModel
{
    public class KudoListViewModel
    {
        public IEnumerable<Kudo> Kudos { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
