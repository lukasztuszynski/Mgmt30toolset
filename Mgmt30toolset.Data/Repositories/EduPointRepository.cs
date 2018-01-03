using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Model;

namespace Mgmt30toolset.Data.Repositories
{
    public class EduPointRepository : Repository<EduPoint>
    {
        public EduPointRepository(ApplicationDbContext context)
            : base(context) { }
    }
}