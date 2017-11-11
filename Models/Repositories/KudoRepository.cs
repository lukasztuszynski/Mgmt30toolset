using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset.Models.Repositories
{
    public class KudoRepository : IKudoRepository
    {
        private readonly ApplicationDbContext _context;

        public KudoRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Kudo> Kudos => _context.Kudos.Where(kudo => kudo.DateDeleted == null)
                                                 .Include(kudo => kudo.Category)
                                                 .Include(kudo => kudo.Receiver)
                                                 .Include(kudo => kudo.Sender);
    }
}
