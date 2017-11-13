using Microsoft.AspNetCore.Mvc;
using Mgmt30toolset.Models;
using Mgmt30toolset.Models.Repositories;
using System.Linq;
using Mgmt30toolset.Models.ViewModels;

namespace Mgmt30toolset.Controllers
{
    public class KudoController : Controller
    {
        private readonly IKudoRepository _repository;
        public int PageSize = 4;

        public KudoController(IKudoRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index(int pageNumber = 1)
        {
            ViewBag.PageNumber = pageNumber;

            return View(new KudoListViewModel
            {
                Kudos = _repository.Kudos
                          .OrderByDescending(kudo => kudo.Id)
                          .Skip((pageNumber - 1) * PageSize)
                          .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNumber,
                    PageSize = PageSize,
                    TotalItems = _repository.Kudos.Count()
                }
            });
        }

        public ViewResult Details(int id)
        {
            var kudo = _repository.Kudos.FirstOrDefault(k => k.Id == id);
            return  View(kudo);
        }
    }
}
