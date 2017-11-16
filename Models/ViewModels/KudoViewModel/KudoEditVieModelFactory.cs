using Mgmt30toolset.Models.Repositories;
using System.Linq;

namespace Mgmt30toolset.Models.ViewModels.KudoViewModel
{
    public class KudoEditViewModelFactory : IKudoEditViewModelFactory
    {
        private readonly IKudoCategoryRepository _kudoCategoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IKudoRepository _kudoRepository;
        public KudoEditViewModelFactory(IKudoRepository kudoRepository, IUserRepository userRepository, IKudoCategoryRepository kudoCategoryRepository)
        {
            _kudoCategoryRepository = kudoCategoryRepository;
            _userRepository = userRepository;
            _kudoRepository = kudoRepository;
        }
        public Kudo Create(KudoEditViewModel kudoViewModel)
        {
            Kudo kudo;
            User sender = _userRepository.Users.First(u => u.Id == kudoViewModel.SenderId);
            User receiver = _userRepository.Users.First(u => u.Id == kudoViewModel.ReceiverId);
            KudoCategory category = _kudoCategoryRepository.KudoCategories.First(c => c.Id == kudoViewModel.CategoryId);

            if (kudoViewModel.Id.HasValue)
            {
                kudo = _kudoRepository.Kudos.First(k => k.Id == kudoViewModel.Id);
            }
            else
            {
                kudo = new Kudo();
                kudo.UserCreated = sender;
            }

            kudo.Category = category;
            kudo.Content = kudoViewModel.Content;
            kudo.Sender = sender;
            kudo.Receiver = receiver;
            kudo.UserUpdated = sender;

            return kudo;
        }
    }
}