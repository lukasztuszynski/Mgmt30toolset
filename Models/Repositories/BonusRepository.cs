using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset.Models.Repositories
{
    public class BonusRepository : IBonusRepository
    {
        private readonly ApplicationDbContext _context;

        public BonusRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Bonus> Bonuses => _context.Bonuses.Where(bonus => bonus.DateDeleted == null)
                                                 .Include(bonus => bonus.Tags)
                                                 .Include(bonus => bonus.Receiver)
                                                 .Include(bonus => bonus.Sender);
    }
}