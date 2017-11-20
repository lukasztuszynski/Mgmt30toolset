using System.Collections.Generic;
using System.Linq;
using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Data.Repositories;
using Mgmt30toolset.Model;

namespace Mgmt30toolset.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void CreateUser(User user);
        void ChangeUser(User user);
        void SaveChanges();
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = userRepository.GetAll().ToList();
            return users;
        }

        public User GetUser(int id)
        {
            var user = userRepository.GetById(id);
            return user;
        }

        public void CreateUser(User user)
        {
            userRepository.Add(user);
        }

        public void ChangeUser(User user)
        {
            userRepository.Update(user);
        }

        public void SaveChanges()
        {
            userRepository.SaveChanges();
        }
    }
}
