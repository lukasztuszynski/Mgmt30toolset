﻿using System.Collections.Generic;
using System.Linq;
using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Data.Repositories;
using Mgmt30toolset.Model;

namespace Mgmt30toolset.Service
{
    public interface IKudoCategoryService
    {
        IEnumerable<KudoCategory> GetCategories();
        KudoCategory GetCategory(int id);
        void CreateCategory(KudoCategory kudoCategory);
        void ChangeCategory(KudoCategory kudoCategory);
        void SaveChanges();
    }

    public class KudoCategoryService : IKudoCategoryService
    {
        private readonly IRepository<KudoCategory> categoryRepository;
        public KudoCategoryService(IRepository<KudoCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<KudoCategory> GetCategories()
        {
            var categories = categoryRepository.GetAll().ToList();
            return categories;
        }

        public KudoCategory GetCategory(int id)
        {
            var category = categoryRepository.Get(c => c.Id == id);
            return category;
        }

        public void CreateCategory(KudoCategory kudoCategory)
        {
            categoryRepository.Add(kudoCategory);
        }

        public void ChangeCategory(KudoCategory kudoCategory)
        {
            categoryRepository.Update(kudoCategory);
        }

        public void SaveChanges()
        {
            categoryRepository.SaveChanges();
        }
    }
}
