using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Data.Repositories;
using Mgmt30toolset.Model;
using System.Collections.Generic;
using System.Linq;

namespace Mgmt30toolset.Service
{
    public interface IKudoService
    {
        IEnumerable<Kudo> GetKudos(int offset, int limit);
        int GetCount();
        Kudo GetKudo(int id);
        void CreateKudo(Kudo kudo);
        void ChangeKudo(Kudo kudo);
        void SaveChanges();
    }

    public class KudoService : IKudoService
    {
        private readonly IKudoRepository kudoRepository;
        private readonly IKudoCategoryRepository categoryRepository;

        public KudoService(IKudoRepository kudoRepository, IKudoCategoryRepository categoryRepository)
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
            var kudo = kudoRepository.GetById(id);
            return kudo;
        }

        public void CreateKudo(Kudo kudo)
        {
            kudoRepository.Add(kudo);
        }

        public void ChangeKudo(Kudo kudo)
        {
            kudoRepository.Update(kudo);
        }

        public void SaveChanges()
        {
            kudoRepository.SaveChanges();
        }

    }
}