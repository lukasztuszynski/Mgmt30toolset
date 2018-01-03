using Mgmt30toolset.Model;
using Mgmt30toolset.Service;
using Mgmt30toolset.Web.ViewModel;
using System.Security.Claims;
using System.Collections.Generic;

namespace Mgmt30toolset.Web.Mapping
{
    public interface IKudoMapper
    {
        KudoViewModel MapKudoModelToViewModel(Kudo kudo);
        KudoFormViewModel CreateKudoFormViewModel(ClaimsPrincipal identity);
        KudoFormViewModel MapKudoModelToFormViewModel(Kudo kudo);
        Kudo MapKudoFormViewModelToModel(KudoFormViewModel kudoForm);
        KudoFormViewModel FillKudoFormViewModel(KudoFormViewModel kudoForm);
    }
    public class KudoMapper : IKudoMapper
    {
        private readonly IKudoCategoryService kudoCategoyService;
        private readonly IUserService userService;
        private readonly IKudoService kudoService;

        public KudoMapper(IKudoService kudoService, IKudoCategoryService kudoCategoryService, IUserService userService)
        {
            this.kudoService = kudoService;
            this.kudoCategoyService = kudoCategoryService;
            this.userService = userService;
        }
        public KudoViewModel MapKudoModelToViewModel(Kudo kudo)
        {
            var kudoViewModel = new KudoViewModel();

            kudoViewModel.Id = kudo.Id;
            kudoViewModel.CategoryId = kudo.Category.Id;
            kudoViewModel.Content = kudo.Content;
            kudoViewModel.Sender = kudo.Sender;
            kudoViewModel.ReceiverId = kudo.Receiver.Id;
            kudoViewModel.DateUpdated = kudo.DateUpdated;

            return kudoViewModel;
        }

        public KudoFormViewModel MapKudoModelToFormViewModel(Kudo kudo)
        {
            IEnumerable<KudoCategory> categories = kudoCategoyService.GetCategories();
            IEnumerable<User> users = userService.GetUsers();

            var kudoFormViewModel = new KudoFormViewModel(categories, users);
            kudoFormViewModel.KudoViewModel = MapKudoModelToViewModel(kudo);
            kudoFormViewModel.KudoViewModel.Sender = kudo.Sender;

            return kudoFormViewModel;
        }

        public KudoFormViewModel CreateKudoFormViewModel(ClaimsPrincipal identity)
        {
            IEnumerable<KudoCategory> categories = kudoCategoyService.GetCategories();
            IEnumerable<User> users = userService.GetUsers();

            var kudoFormViewModel = new KudoFormViewModel(categories, users);
            kudoFormViewModel.KudoViewModel = new KudoViewModel();
            kudoFormViewModel.KudoViewModel.Sender = userService.GetUser(identity);

            return kudoFormViewModel;
        }

        public Kudo MapKudoFormViewModelToModel(KudoFormViewModel kudoForm)
        {
            Kudo kudo;

            if (kudoForm.KudoViewModel.Id.HasValue)
            {
                kudo = kudoService.GetKudo(kudoForm.KudoViewModel.Id.Value);
            }
            else
            {
                kudo = new Kudo();
            }

            kudo.Category = kudoCategoyService.GetCategory(kudoForm.KudoViewModel.CategoryId.Value);
            kudo.Receiver = userService.GetUser(kudoForm.KudoViewModel.ReceiverId);
            kudo.Content = kudoForm.KudoViewModel.Content;

            return kudo;
        }

        public KudoFormViewModel FillKudoFormViewModel(KudoFormViewModel kudoForm)
        {
            kudoForm.SetUsers(userService.GetUsers());
            kudoForm.SetCategories(kudoCategoyService.GetCategories());
            kudoForm.KudoViewModel.Sender = userService.GetUser(kudoForm.KudoViewModel.Sender.Id);

            return kudoForm;
        }

    }
}
