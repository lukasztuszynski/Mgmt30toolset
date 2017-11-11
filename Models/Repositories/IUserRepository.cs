using System.Linq;

namespace Mgmt30toolset.Models.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}
