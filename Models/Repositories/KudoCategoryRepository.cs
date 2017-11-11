using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset.Models.Repositories
{
    public class KudoCategoryRepository : IKudoCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public KudoCategoryRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<KudoCategory> KudoCategories => _context.KudoCategories.Where(category => category.DateDeleted == null);
    }
}
