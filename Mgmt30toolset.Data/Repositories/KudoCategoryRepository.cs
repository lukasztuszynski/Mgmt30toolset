using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Model;

namespace Mgmt30toolset.Data.Repositories
{
    public interface IKudoCategoryRepository : IRepository<KudoCategory>
    {

    }

    public class KudoCategoryRepository : Repository<KudoCategory>, IKudoCategoryRepository
    {
        public KudoCategoryRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
