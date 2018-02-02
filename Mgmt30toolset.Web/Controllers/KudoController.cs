using Mgmt30toolset.Model;
using Mgmt30toolset.Service;
using Mgmt30toolset.Web.Mapping;
using Mgmt30toolset.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Mgmt30toolset.Controllers
{
    public class KudoController : Controller
    {
        private readonly IKudoService kudoService;
        private readonly IUserService userService;
        private readonly IKudoMapper kudoMapper;
        private readonly int pageSize;

        public KudoController(IConfiguration configuration, IKudoService kudoService, IUserService userService, IKudoMapper kudoMapper)
        {
            this.kudoService = kudoService;
            this.userService = userService;
            this.kudoMapper = kudoMapper;
            this.pageSize = int.Parse(configuration["AppData:CardViewIndexPageSize"]);
        }

        [Authorize]
        public ViewResult Index(int pageNumber = 1)
        {
            var kudoListViewModel = new KudoListViewModel
            {
                Kudos = kudoService.GetKudos(pageNumber, pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNumber,
                    PageSize = this.pageSize,
                    TotalItems = kudoService.GetCount()
                }
            };

            return View(kudoListViewModel);
        }

        [Authorize]
        public ViewResult Details(int id)
        {
            Kudo kudo = kudoService.GetKudo(id);
            return View(kudo);
        }

        [Authorize]
        public ViewResult Edit(int id)
        {
            Kudo kudo = kudoService.GetKudo(id);
            KudoFormViewModel kudoForm = kudoMapper.MapKudoModelToFormViewModel(kudo);
            return View("Edit", kudoForm);
        }

        [Authorize]
        public ViewResult Create()
        {
            KudoFormViewModel kudoForm = kudoMapper.CreateKudoFormViewModel(this.User);
            return View("Edit", kudoForm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KudoFormViewModel kudoForm)
        {
            if (ModelState.IsValid)
            {
                Kudo kudo = kudoMapper.MapKudoFormViewModelToModel(kudoForm);

                if (kudoForm.KudoViewModel.Id.HasValue)
                {
                    kudoService.ChangeKudo(kudo);
                }
                else
                {
                    User sender = userService.GetUser(this.User);
                    kudoService.CreateKudo(kudo, sender);
                }

                kudoService.SaveChanges();

                return RedirectToAction("Details", new { id = kudo.Id });
            }
            else
            {
                kudoMapper.FillKudoFormViewModel(kudoForm);
                return View(kudoForm);
            }
        }
    }
}