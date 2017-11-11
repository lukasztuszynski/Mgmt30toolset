using System.Linq;

namespace Mgmt30toolset.Models.Repositories
{
    public interface IKudoRepository
    {
        IQueryable<Kudo> Kudos { get; }
    }
}
