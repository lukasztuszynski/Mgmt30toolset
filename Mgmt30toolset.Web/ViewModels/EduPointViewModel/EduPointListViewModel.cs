using Mgmt30toolset.Model;
using System.Collections.Generic;

namespace Mgmt30toolset.Web.ViewModel
{
    public class EduPointListViewModel
    {
        public IEnumerable<EduPoint> EduPoints { get; set; }
        public decimal Total { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
