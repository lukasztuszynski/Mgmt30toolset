using Mgmt30toolset.Data;
using Mgmt30toolset.Data.Repositories;
using Mgmt30toolset.Service;
using Mgmt30toolset.Web.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Mgmt30toolset.Model;
using Mgmt30toolset.Data.Infrastructure;

namespace Mgmt30toolset
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration["Data:Mgmt30toolset:ConnectionString"], b => b.MigrationsAssembly("Mgmt30toolset.Web")));

            services.AddTransient<IKudoService, KudoService>();
            services.AddTransient<IKudoCategoryService, KudoCategoryService>();
            services.AddTransient<IEduPointService, EduPointService>();
            services.AddTransient<IEduPointCategoryService, EduPointCategoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRepository<Kudo>, KudoRepository>();
            services.AddTransient<IRepository<KudoCategory>, Repository<KudoCategory>>();
            services.AddTransient<IRepository<EduPoint>, EduPointRepository>();
            services.AddTransient<IRepository<EduPointCategory>, Repository<EduPointCategory>>();
            services.AddTransient<IKudoMapper, KudoMapper>();
            services.AddTransient<IEduPointMapper, EduPointMapper>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseAuthentication();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "pagination",
                        template: "{controller}/Page{pageNumber}",
                        defaults: new { action = "Index" });

                    routes.MapRoute(
                        name: "kudoDetails",
                        template: "{controller}/{id:int}",
                        defaults: new { action = "Details" });

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Kudo}/{action=Index}/{id?}");
                });

                ApplicationDbSeed.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
                ApplicationDbSeed.EnsureSeeded(app.ApplicationServices, Configuration);
            }
        }
    }
}
