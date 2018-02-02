using Mgmt30toolset.Model;
using Mgmt30toolset.Service;
using Mgmt30toolset.Web.Mapping;
using Mgmt30toolset.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Mgmt30toolset.Controllers
{
    public class EduPointController : Controller
    {
        private readonly IEduPointService eduPointService;
        private readonly IUserService userService;
        private readonly IEduPointMapper pointMapper;
        private readonly int pageSize;

        public EduPointController(IConfiguration configuration, IEduPointService eduPointService, IUserService userService, IEduPointMapper pointMapper)
        {
            this.eduPointService = eduPointService;
            this.userService = userService;
            this.pointMapper = pointMapper;
            this.pageSize = int.Parse(configuration["Data:Mgmt30toolset:IndexPageSize"]);
        }

        [Authorize]
        public ViewResult Index(int pageNumber = 1)
        {
            User reciever = userService.GetUser(this.User);

            var eduPointListViewModel = new EduPointListViewModel
            {
                EduPoints = eduPointService.GetUserPoints(reciever.Id, pageNumber, pageSize),
                Total = eduPointService.GetSum() ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNumber,
                    PageSize = this.pageSize,
                    TotalItems = eduPointService.GetCount()
                }
            };

            return View(eduPointListViewModel);
        }

        [Authorize]
        public ViewResult Edit(int id)
        {
            EduPoint point = eduPointService.GetPoint(id);
            EduPointTransferFormViewModel pointForm = pointMapper.MapEduPointModelToTransferFormViewModel(point);
            return View("Transfer", pointForm);
        }

        [Authorize]
        public ViewResult Transfer()
        {
            EduPointTransferFormViewModel pointForm = pointMapper.CreateEduPointTransferFormViewModel(this.User);
            return View("Transfer", pointForm);
        }
        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(EduPointTransferFormViewModel pointForm)
        {
            if (ModelState.IsValid)
            {
                EduPoint point = pointMapper.MapEduPointTransferFormViewModelToModel(pointForm);

                if (pointForm.EduPointViewModel.Id.HasValue)
                {
                    eduPointService.ChangePoint(point);
                }
                else
                {
                    User sender = userService.GetUser(this.User);
                    eduPointService.CreatePoint(point, sender);
                }

                eduPointService.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                pointMapper.FillEduPointTransferFormViewModel(pointForm);
                return View(pointForm);
            }
        }
    }
}