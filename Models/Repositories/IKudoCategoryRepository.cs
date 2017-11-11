using System.Linq;

namespace Mgmt30toolset.Models.Repositories
{
    public interface IKudoCategoryRepository
    {
        IQueryable<KudoCategory> KudoCategories { get; }
    }
}
