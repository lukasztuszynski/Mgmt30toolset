using Mgmt30toolset.Model;
using Mgmt30toolset.Service;
using Mgmt30toolset.Web.ViewModel;
using System.Security.Claims;
using System.Collections.Generic;

namespace Mgmt30toolset.Web.Mapping
{
    public interface IEduPointMapper
    {
        EduPointViewModel MapEduPointModelToViewModel(EduPoint point);
        EduPointTransferFormViewModel CreateEduPointTransferFormViewModel(ClaimsPrincipal identity);
        EduPointTransferFormViewModel MapEduPointModelToTransferFormViewModel(EduPoint point);
        EduPoint MapEduPointTransferFormViewModelToModel(EduPointTransferFormViewModel pointForm);
        EduPointTransferFormViewModel FillEduPointTransferFormViewModel(EduPointTransferFormViewModel pointForm);
    }
    public class EduPointMapper : IEduPointMapper
    {
        private readonly IEduPointService pointService;
        private readonly IUserService userService;
        private readonly IEduPointCategoryService pointCategoryService;

        public EduPointMapper(IEduPointService pointService, IEduPointCategoryService pointCategoryService, IUserService userService)
        {
            this.pointService = pointService;
            this.pointCategoryService = pointCategoryService;
            this.userService = userService;
        }
        public EduPointViewModel MapEduPointModelToViewModel(EduPoint point)
        {
            var eduPointViewModel = new EduPointViewModel();

            eduPointViewModel.Id = point.Id;
            eduPointViewModel.CategoryId = point.Category.Id;
            eduPointViewModel.Description = point.Description;
            eduPointViewModel.Sender = point.Sender;
            eduPointViewModel.ReceiverId = point.Receiver.Id;
            eduPointViewModel.Amount = point.Amount;

            return eduPointViewModel;
        }

        public EduPointTransferFormViewModel MapEduPointModelToTransferFormViewModel(EduPoint point)
        {
            IEnumerable<EduPointCategory> categories = pointCategoryService.GetCategories();
            IEnumerable<User> users = userService.GetUsers();

            var eduPointTransferFormViewModel = new EduPointTransferFormViewModel(categories, users);
            eduPointTransferFormViewModel.EduPointViewModel = MapEduPointModelToViewModel(point);
            eduPointTransferFormViewModel.EduPointViewModel.Sender = point.Sender;

            return eduPointTransferFormViewModel;
        }

        public EduPointTransferFormViewModel CreateEduPointTransferFormViewModel(ClaimsPrincipal identity)
        {
            IEnumerable<EduPointCategory> categories = pointCategoryService.GetCategories();
            IEnumerable<User> users = userService.GetUsers();

            var eduPointTransferFormViewModel = new EduPointTransferFormViewModel(categories, users);
            eduPointTransferFormViewModel.EduPointViewModel = new EduPointViewModel();
            eduPointTransferFormViewModel.EduPointViewModel.Sender = userService.GetUser(identity);

            return eduPointTransferFormViewModel;
        }

        public EduPoint MapEduPointTransferFormViewModelToModel(EduPointTransferFormViewModel pointForm)
        {
            EduPoint point;

            if (pointForm.EduPointViewModel.Id.HasValue)
            {
                point = pointService.GetPoint(pointForm.EduPointViewModel.Id.Value);
            }
            else
            {
                point = new EduPoint();
            }

            point.Category = pointCategoryService.GetCategory(pointForm.EduPointViewModel.CategoryId.Value);
            point.Receiver = userService.GetUser(pointForm.EduPointViewModel.ReceiverId);
            point.Description = pointForm.EduPointViewModel.Description;
            point.Amount = pointForm.EduPointViewModel.Amount;

            return point;
        }

        public EduPointTransferFormViewModel FillEduPointTransferFormViewModel(EduPointTransferFormViewModel pointForm)
        {
            pointForm.SetUsers(userService.GetUsers());
            pointForm.SetCategories(pointCategoryService.GetCategories());
            pointForm.EduPointViewModel.Sender = userService.GetUser(pointForm.EduPointViewModel.Sender.Id);

            return pointForm;
        }

    }
}
