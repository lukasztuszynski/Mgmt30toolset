using System.Collections.Generic;
using System.Linq;
using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Data.Repositories;
using Mgmt30toolset.Model;

namespace Mgmt30toolset.Service
{
    public interface IEduPointCategoryService
    {
        IEnumerable<EduPointCategory> GetCategories();
        EduPointCategory GetCategory(int id);
        void CreateCategory(EduPointCategory eduPointCategory);
        void ChangeCategory(EduPointCategory eduPointCategory);
        void SaveChanges();
    }

    public class EduPointCategoryService : IEduPointCategoryService
    {
        private readonly IRepository<EduPointCategory> categoryRepository;
        public EduPointCategoryService(IRepository<EduPointCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<EduPointCategory> GetCategories()
        {
            var categories = categoryRepository.GetAll().ToList();
            return categories;
        }

        public EduPointCategory GetCategory(int id)
        {
            var category = categoryRepository.Get(c => c.Id == id);
            return category;
        }

        public void CreateCategory(EduPointCategory eduPointCategory)
        {
            categoryRepository.Add(eduPointCategory);
        }

        public void ChangeCategory(EduPointCategory eduPointCategory)
        {
            categoryRepository.Update(eduPointCategory);
        }

        public void SaveChanges()
        {
            categoryRepository.SaveChanges();
        }
    }
}
