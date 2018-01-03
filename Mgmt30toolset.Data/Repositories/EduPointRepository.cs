using System;
using System.Linq;
using System.Linq.Expressions;
using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Model;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset.Data.Repositories
{
    public class EduPointRepository : Repository<EduPoint>
    {
        public EduPointRepository(ApplicationDbContext context)
            : base(context) { }


        public override IQueryable<EduPoint> GetAll()
        {
            var eduPoints = base.GetAll()
                                    .Include(point => point.Category)
                                    .Include(point => point.Receiver)
                                    .Include(point => point.Sender);
            return eduPoints;
        }

        public override EduPoint Get(Expression<Func<EduPoint, bool>> where)
        {
            var eduPoint = base.GetAll().Where(where)
                                    .Include(point => point.Category)
                                    .Include(point => point.Receiver)
                                    .Include(point => point.Sender)
                                    .FirstOrDefault();
            return eduPoint;
        }
    }
}