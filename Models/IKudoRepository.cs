using System.Linq;

namespace Mgmt30toolset.Models
{
    public interface IKudoRepository
    {
        IQueryable<Kudo> Kudos { get; }
    }
}
