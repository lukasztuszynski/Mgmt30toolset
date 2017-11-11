using System.Linq;

namespace Mgmt30toolset.Models.Repositories
{
    public interface IBonusRepository
    {
        IQueryable<Bonus> Bonuses { get; }
    }
}
