using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Model;

namespace Mgmt30toolset.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
