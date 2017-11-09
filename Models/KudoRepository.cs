using System.Linq;

namespace Mgmt30toolset.Models
{
    public class KudoRepository : IKudoRepository
    {
        private readonly ApplicationDbContext _context;

        public KudoRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Kudo> Kudos => _context.Kudos.Where(kudo => kudo.DateDeleted == null);
    }
}
