using System.Collections.Generic;

namespace Mgmt30toolset.Models.ViewModels
{
    public class KudoListViewModel
    {
        public IEnumerable<Kudo> Kudos { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
