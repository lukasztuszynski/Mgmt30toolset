using Mgmt30toolset.Model;
using System;
using System.Linq;

namespace Mgmt30toolset.Data
{
    public static class ApplicationDbSeed
    {
        public static void EnsureSeeded(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var admin = new User
            {
                FirstName = "Administrator",
                Password = "admin",
                Username = "admin",
            };

            context.Users.Add(admin);
            context.SaveChanges();

            admin.UserCreated = admin.UserUpdated = admin;
            context.SaveChanges();

            var category1 = new KudoCategory
            {
                Name = "Totally awesome!",
                Description = "When you'd like to admire someone for great job or an idea.",
                UserCreated = admin,
                UserUpdated = admin
            };

            var category2 = new KudoCategory
            {
                Name = "Thank you!",
                Description = "When you'd like to thank someone for helping you out, or other gift of her heart.",
                UserCreated = admin,
                UserUpdated = admin
            };

            var category3 = new KudoCategory
            {
                Name = "Congratulation!",
                Description = "Whene you'd like to congratulate someone for her success.",
                UserCreated = admin,
                UserUpdated = admin
            };

            context.KudoCategories.AddRange(category1, category2, category3);
            context.SaveChanges();
        }
    }
}
