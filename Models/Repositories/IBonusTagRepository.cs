using System.Linq;

namespace Mgmt30toolset.Models.Repositories
{
    public interface IBonusTagRepository
    {
        IQueryable<BonusTag> BonusTags { get; }
    }
}
