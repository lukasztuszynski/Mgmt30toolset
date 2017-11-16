using Microsoft.AspNetCore.Mvc;
using Mgmt30toolset.Models;
using Mgmt30toolset.Models.Repositories;
using System.Linq;
using Mgmt30toolset.Models.ViewModels.KudoViewModel;
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
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly IKudoEditViewModelFactory _kudoEditViewModelFactory;

        public KudoController(IConfiguration configuration, IKudoEditViewModelFactory kudoEditViewModelFactory, IKudoRepository kudoRepo, IKudoCategoryRepository kudoCategoryRepo, IUserRepository userRepo)
        {
            _config = configuration;
            _kudoRepository = kudoRepo;
            _kudoCategoryRepository = kudoCategoryRepo;
            _userRepository = userRepo;
            _kudoEditViewModelFactory = kudoEditViewModelFactory;
        }
       
        public ViewResult Index(int pageNumber = 1)
        {
            int pageSize = int.Parse(_config["Data:Mgmt30toolset:IndexPageSize"]);

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

            ViewBag.SenderList = _userRepository.Users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}".Trim(),
                Selected = u.Id == kudo.Sender.Id
            });

            ViewBag.ReceiverList = _userRepository.Users.Select(u => new SelectListItem
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

            ViewBag.ReceiverList = ViewBag.SenderList = _userRepository.Users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}".Trim(),
            });

            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KudoEditViewModel kudoEditViewModel)
        {
            Kudo kudo = _kudoEditViewModelFactory.Create(kudoEditViewModel);

            if (kudoEditViewModel.Id.HasValue)
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
