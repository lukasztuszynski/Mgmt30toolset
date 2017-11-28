using System;
using System.Linq;
using System.Linq.Expressions;
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

        public override Kudo Get(Expression<Func<Kudo, bool>> where)
        {
            var kudo = base.GetAll().Where(where)
                                    .Include(k => k.Category)
                                    .Include(k => k.Receiver)
                                    .Include(k => k.Sender)
                                    .FirstOrDefault();
            return kudo;
        }

    }
}
