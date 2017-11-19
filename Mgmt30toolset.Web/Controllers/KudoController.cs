using Mgmt30toolset.Web.ViewModel;
using Mgmt30toolset.Web.Mapping;
using Mgmt30toolset.Service;
using Mgmt30toolset.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Mgmt30toolset.Controllers
{
    public class KudoController : Controller
    {
        private readonly IKudoService kudoService;
        private readonly IKudoMapper kudoMapper;
        private readonly int pageSize;

        public KudoController(IConfiguration configuration, IKudoService kudoService, IKudoMapper kudoMapper)
        {
            this.kudoService = kudoService;
            this.kudoMapper = kudoMapper;
            this.pageSize = int.Parse(configuration["Data:Mgmt30toolset:IndexPageSize"]);
        }

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

        public ViewResult Details(int id)
        {
            Kudo kudo = kudoService.GetKudo(id);
            return View(kudo);
        }

        public ViewResult Edit(int id)
        {
            Kudo kudo = kudoService.GetKudo(id);
            KudoFormViewModel kudoForm = kudoMapper.MapKudoModelToFormViewModel(kudo);
            return View("Edit", kudoForm);
        }

        public ViewResult Create()
        {
            KudoFormViewModel kudoForm = kudoMapper.CreateKudoFormViewModel();
            return View("Edit", kudoForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KudoFormViewModel kudoForm)
        {
            Kudo kudo = kudoMapper.MapKudoFormViewModelToModel(kudoForm);

            if (kudoForm.KudoViewModel.Id.HasValue)
            {
                kudoService.ChangeKudo(kudo);
            }
            else
            {
                kudoService.CreateKudo(kudo);
            }

            kudoService.SaveChanges();

            return RedirectToAction("Details", new { id = kudo.Id });
        }
    }
}
