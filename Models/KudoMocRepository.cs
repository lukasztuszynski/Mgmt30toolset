using System;
using System.Linq;
using System.Collections.Generic;

namespace Mgmt30toolset.Models
{
    public class KudoMocRepository : IKudoRepository
    {
        public IQueryable<Kudo> Kudos
        {
            get
            {
                var user1 = new User
                {
                    Email = "user1@email.com",
                    FirstName = "User",
                    LastName = "One",
                    Password = "password1",
                    Username = "user1name"
                };

                user1.UserCreated = user1;
                user1.UserUpdated = user1;

                var user2 = new User
                {
                    Email = "user2@email.com",
                    FirstName = "User",
                    LastName = "Two",
                    Password = "password2",
                    Username = "user2name",
                    UserCreated = user1,
                    UserUpdated = user1
                };

                var kudoCategory1 = new KudoCategory
                {
                    Id = 1,
                    Name = "Thanks",
                    UserCreated = user1,
                    UserUpdated = user1
                };

                var kudoCategory2 = new KudoCategory
                {
                    Id = 2,
                    Name = "Congratulation",
                    UserCreated = user1,
                    UserUpdated = user1
                };

                var kudo1 = new Kudo
                {
                    Category = kudoCategory1,
                    Content = "Thank you for helping me with ASP.NET MVC Core 2.0 !",
                    Id = 1,
                    Receiver = user2,
                    Sender = user1,
                    UserCreated = user1,
                    UserUpdated = user1
                };

                var kudo2 = new Kudo
                {
                    Category = kudoCategory2,
                    Content = "Congratulation for amaizing job with EPI !",
                    Id = 2,
                    Receiver = user1,
                    Sender = user2,
                    UserCreated = user2,
                    UserUpdated = user2
                };

                return new List<Kudo> { kudo1, kudo2 }.AsQueryable<Kudo>();
            }
        }
    }
}
