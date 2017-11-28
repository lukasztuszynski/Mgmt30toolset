using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Mgmt30toolset.Model;
using System.Security.Claims;

namespace Mgmt30toolset.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(string id);
        User GetUser(ClaimsPrincipal identity);
        void CreateUser(User user, string password);
        void ChangeUser(User user);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = userManager.Users.ToList();
            return users;
        }

        public User GetUser(string id)
        {
            var user = userManager.Users.First(u => u.Id == id);
            return user;
        }

        public User GetUser(ClaimsPrincipal identity)
        {
            var users = userManager.Users.First(u => u.Id == userManager.GetUserId(identity));
            return users;
        }

        public void CreateUser(User user, string password)
        {
            userManager.CreateAsync(user, password);
        }

        public void ChangeUser(User user)
        {
            userManager.UpdateAsync(user);
        }
    }
}
