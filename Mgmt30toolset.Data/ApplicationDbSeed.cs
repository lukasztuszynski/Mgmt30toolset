using Mgmt30toolset.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Mgmt30toolset.Data
{
    public static class ApplicationDbSeed
    {
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = configuration["SeedData:AdminUser:UserName"];
            string email = configuration["SeedData:AdminUser:Email"];
            string password = configuration["SeedData:AdminUser:Password"];
            string firstName = configuration["SeedData:AdminUser:FirstName"];
            string lastName = configuration["SeedData:AdminUser:LastName"];
            string role = configuration["SeedData:AdminUser:Role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                User user = new User
                {
                    UserName = username,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
        public static void EnsureSeeded(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            ApplicationDbContext dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();

            if (dbContext.EduPointCategories.Any())
            {
                return;
            }

            User admin = dbContext.Users.Where(u => u.UserName == configuration["SeedData:AdminUser:UserName"]).FirstOrDefault();
            if (admin == null)
            {
                return;
            }

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

            dbContext.KudoCategories.AddRange(category1, category2, category3);

            var eduCategory1 = new EduPointCategory
            {
                Name = "Regular",
                Description = "Regular points transfered each month.",
                UserCreated = admin,
                UserUpdated = admin
            };

            var eduCategory2 = new EduPointCategory
            {
                Name = "Bonus",
                Description = "Bonus points transfered arbitrarily.",
                UserCreated = admin,
                UserUpdated = admin
            };

            dbContext.EduPointCategories.AddRange(eduCategory1, eduCategory2);
            dbContext.SaveChanges();
        }
    }
}
