using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset.Models.Repositories
{
    public class BonusTagRepository : IBonusTagRepository
    {
        private readonly ApplicationDbContext _context;

        public BonusTagRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<BonusTag> BonusTags => _context.BonusTags.Where(tag => tag.DateDeleted == null);
    }
}
