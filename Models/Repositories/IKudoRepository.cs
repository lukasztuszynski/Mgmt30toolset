using System.Linq;

namespace Mgmt30toolset.Models.Repositories
{
    public interface IKudoRepository
    {
        IQueryable<Kudo> Kudos { get; }
        Kudo Create(Kudo kudo);
        Kudo Edit(Kudo kudo);
    }
}
