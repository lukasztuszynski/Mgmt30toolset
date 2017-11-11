using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<User> Users => _context.Users.Where(user => user.DateDeleted == null);
    }
}
