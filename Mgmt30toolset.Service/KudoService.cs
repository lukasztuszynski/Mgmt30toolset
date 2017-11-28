using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Data.Repositories;
using Mgmt30toolset.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Mgmt30toolset.Service
{
    public interface IKudoService
    {
        IEnumerable<Kudo> GetKudos(int offset, int limit);
        int GetCount();
        Kudo GetKudo(int id);
        void CreateKudo(Kudo kudo, User sender);
        void ChangeKudo(Kudo kudo);
        void SaveChanges();
    }

    public class KudoService : IKudoService
    {
        private readonly IRepository<Kudo> kudoRepository;
        private readonly IRepository<KudoCategory> categoryRepository;

        public KudoService(IRepository<Kudo> kudoRepository, IRepository<KudoCategory> categoryRepository)
        {
            this.kudoRepository = kudoRepository;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Kudo> GetKudos(int offset, int limit)
        {
            var kudos = kudoRepository.GetAll()
                                      .OrderByDescending(kudo => kudo.Id)
                                      .Skip((offset - 1) * limit)
                                      .Take(limit).ToList();
            return kudos;
        }

        public int GetCount()
        {
            int count = kudoRepository.GetAll().Count();
            return count;
        }

        public Kudo GetKudo(int id)
        {
            var kudo = kudoRepository.Get(k => k.Id == id);
            return kudo;
        }

        public void CreateKudo(Kudo kudo, User sender)
        {
            kudo.DateCreated = DateTime.UtcNow;
            kudo.DateUpdated = DateTime.UtcNow;
            kudo.Sender = sender;
            kudoRepository.Add(kudo);
        }

        public void ChangeKudo(Kudo kudo)
        {
            kudo.DateUpdated = DateTime.UtcNow;
            kudoRepository.Update(kudo);
        }

        public void SaveChanges()
        {
            kudoRepository.SaveChanges();
        }

    }
}
