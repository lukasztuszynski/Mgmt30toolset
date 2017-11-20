using System.Linq;
using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Model;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset.Data.Repositories
{
    public class KudoRepository : Repository<Kudo>
    {
        public KudoRepository(ApplicationDbContext context)
            : base(context) { }

        public override IQueryable<Kudo> GetAll()
        {
            var kudos = base.GetAll()
                                    .Include(kudo => kudo.Category)
                                    .Include(kudo => kudo.Receiver)
                                    .Include(kudo => kudo.Sender);
            return kudos;
        }

        public override Kudo GetById(int id)
        {
            var kudo = base.GetMany(k=>k.Id == id)
                                    .Include(k => k.Category)
                                    .Include(k => k.Receiver)
                                    .Include(k => k.Sender)
                                    .First();
            return kudo;
        }

    }
}
