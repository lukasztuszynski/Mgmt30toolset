using Mgmt30toolset.Model;
using Mgmt30toolset.Service;
using Mgmt30toolset.Web.ViewModel;

namespace Mgmt30toolset.Web.Mapping
{
    public interface IKudoMapper
    {
        KudoViewModel MapKudoModelToViewModel(Kudo kudo);
        KudoFormViewModel CreateKudoFormViewModel();
        KudoFormViewModel MapKudoModelToFormViewModel(Kudo kudo);
        Kudo MapKudoFormViewModelToModel(KudoFormViewModel kudoForm);
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
            kudoViewModel.SenderId = kudo.Sender.Id;
            kudoViewModel.ReceiverId = kudo.Receiver.Id;
            kudoViewModel.DateUpdated = kudo.DateUpdated;

            return kudoViewModel;
        }

        public KudoFormViewModel MapKudoModelToFormViewModel(Kudo kudo)
        {
            var kudoFormViewModel = new KudoFormViewModel();

            kudoFormViewModel.KudoViewModel = MapKudoModelToViewModel(kudo);
            kudoFormViewModel.Categories = kudoCategoyService.GetCategories();
            kudoFormViewModel.Users = userService.GetUsers();

            return kudoFormViewModel;
        }

        public KudoFormViewModel CreateKudoFormViewModel()
        {
            var kudoFormViewModel = new KudoFormViewModel();

            kudoFormViewModel.Categories = kudoCategoyService.GetCategories();
            kudoFormViewModel.Users = userService.GetUsers();

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

            kudo.Category = kudoCategoyService.GetCategory(kudoForm.KudoViewModel.CategoryId);
            kudo.Sender = userService.GetUser(kudoForm.KudoViewModel.SenderId);
            kudo.Receiver = userService.GetUser(kudoForm.KudoViewModel.ReceiverId);
            kudo.Content = kudoForm.KudoViewModel.Content;

            return kudo;
        }

    }
}
