using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace Mgmt30toolset.Models
{
    public static class ApplicationDbSeed
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Users.Any())
            {
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
            }

            if (!context.KudoCategories.Any())
            {
                var admin = context.Users.FirstOrDefault(user => user.Username == "admin");
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
}