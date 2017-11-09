using Microsoft.AspNetCore.Mvc;
using Mgmt30toolset.Models;

namespace Mgmt30toolset.Controllers
{
    public class KudoController:Controller
    {
        private readonly IKudoRepository _repository;

        public KudoController(IKudoRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index() => View(_repository.Kudos);
    }
}
