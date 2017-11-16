using Microsoft.AspNetCore.Mvc;
using Mgmt30toolset.Models;
using Mgmt30toolset.Models.Repositories;
using System.Linq;
using Mgmt30toolset.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace Mgmt30toolset.Controllers
{
    public class KudoController : Controller
    {
        private readonly IKudoRepository _kudoRepository;
        private readonly IKudoCategoryRepository _kudoCategoryRepository;
        private readonly IUserRepository _userRepoository;
        private readonly IConfiguration _config;

        public KudoController(IConfiguration configuration, IKudoRepository kudoRepo, IKudoCategoryRepository kudoCategoryRepo, IUserRepository userRepo)
        {
            _config = configuration;
            _kudoRepository = kudoRepo;
            _kudoCategoryRepository = kudoCategoryRepo;
            _userRepoository = userRepo;
        }

        private Kudo MapKudoModel(KudoEditViewModel kudoViewModel)
        {
            Kudo kudo;

            if (kudoViewModel.Id.HasValue)
            {
                kudo = _kudoRepository.Kudos.First(k => k.Id == kudoViewModel.Id);
                kudo.UserUpdated = kudo.Sender = _userRepoository.Users.First(u => u.Id == kudoViewModel.SenderId);
            }
            else
            {
                kudo = new Kudo();
                kudo.UserCreated = kudo.UserUpdated = kudo.Sender = _userRepoository.Users.First(u => u.Id == kudoViewModel.SenderId);
            }

            kudo.Category = _kudoCategoryRepository.KudoCategories.First(c => c.Id == kudoViewModel.CategoryId);
            kudo.Receiver = _userRepoository.Users.First(u => u.Id == kudoViewModel.ReceiverId);
            kudo.Content = kudoViewModel.Content;

            return kudo;
        }

        public ViewResult Index(int pageNumber = 1)
        {
            int pageSize = int.Parse(_config["Data:Mgmt30toolset:IndexPageSize"]);
            ViewBag.PageNumber = pageNumber;

            return View(new KudoListViewModel
            {
                Kudos = _kudoRepository.Kudos
                          .OrderByDescending(kudo => kudo.Id)
                          .Skip((pageNumber - 1) * pageSize)
                          .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = _kudoRepository.Kudos.Count()
                }
            });
        }

        public ViewResult Details(int id)
        {
            return View(_kudoRepository.Kudos.First(k => k.Id == id));
        }

        public ViewResult Edit(int id)
        {
            var kudo = _kudoRepository.Kudos.First(k => k.Id == id);
            var kudoData = new KudoEditViewModel(kudo);

            ViewBag.CategoryList = _kudoCategoryRepository.KudoCategories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = c.Id == kudo.Category.Id
            });

            ViewBag.SenderList = _userRepoository.Users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}".Trim(),
                Selected = u.Id == kudo.Sender.Id
            });

            ViewBag.ReceiverList = _userRepoository.Users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}".Trim(),
                Selected = u.Id == kudo.Receiver.Id
            });

            return View("Edit", kudoData);
        }

        public ViewResult Create()
        {
            ViewBag.CategoryList = _kudoCategoryRepository.KudoCategories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            });

            ViewBag.ReceiverList = ViewBag.SenderList = _userRepoository.Users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}".Trim(),
            });

            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KudoEditViewModel kudoViewModel)
        {
            Kudo kudo = MapKudoModel(kudoViewModel);

            if (kudoViewModel.Id.HasValue)
            {
                _kudoRepository.Edit(kudo);
            }
            else
            {
                _kudoRepository.Create(kudo);
            }

            return RedirectToAction("Details", new { id = kudo.Id });
        }
    }
}
