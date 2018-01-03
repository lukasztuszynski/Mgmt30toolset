using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Data.Repositories;
using Mgmt30toolset.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Mgmt30toolset.Service
{
    public interface IEduPointService
    {
        IEnumerable<EduPoint> GetPoints(int offset, int limit);
        int GetCount();
        EduPoint GetPoint(int id);
        void CreatePoint(EduPoint eduPoint, User sender);
        void ChangePoint(EduPoint eduPoint);
        void SaveChanges();
    }

    public class EduPointService : IEduPointService
    {
        private readonly IRepository<EduPoint> eduPointRepository;
        private readonly IRepository<EduPointCategory> categoryRepository;

        public EduPointService(IRepository<EduPoint> eduPointRepository, IRepository<EduPointCategory> categoryRepository)
        {
            this.eduPointRepository = eduPointRepository;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<EduPoint> GetPoints(int offset, int limit)
        {
            var eduPoints = eduPointRepository.GetAll()
                                      .OrderByDescending(point => point.Id)
                                      .Skip((offset - 1) * limit)
                                      .Take(limit).ToList();
            return eduPoints;
        }

        public int GetCount()
        {
            int count = eduPointRepository.GetAll().Count();
            return count;
        }

        public EduPoint GetPoint(int id)
        {
            var eduPoint = eduPointRepository.Get(point => point.Id == id);
            return eduPoint;
        }

        public void CreatePoint(EduPoint eduPoint, User sender)
        {
            eduPoint.DateCreated = DateTime.UtcNow;
            eduPoint.DateUpdated = DateTime.UtcNow;
            eduPoint.Sender = sender;
            eduPointRepository.Add(eduPoint);
        }

        public void ChangePoint(EduPoint eduPoint)
        {
            eduPoint.DateUpdated = DateTime.UtcNow;
            eduPointRepository.Update(eduPoint);
        }

        public void SaveChanges()
        {
            eduPointRepository.SaveChanges();
        }
    }
}
