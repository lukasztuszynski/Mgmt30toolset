using Mgmt30toolset.Data;
using Mgmt30toolset.Data.Infrastructure;
using Mgmt30toolset.Data.Repositories;
using Mgmt30toolset.Model;
using Mgmt30toolset.Service;
using Mgmt30toolset.Web.Mapping;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Mgmt30toolset
{
    public class Startup
    {
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("./appsettings.json")
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Mgmnt30Toolset"));
            } else
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["AppData:ConnectionString"], b => b.MigrationsAssembly("Mgmt30toolset.Web")));
            }

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

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["AuthenticationData:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["AuthenticationData:Google:ClientSecret"];

                googleOptions.Events = new OAuthEvents()
                {
                    OnRedirectToAuthorizationEndpoint = context =>
                    {
                        context.Response.Redirect($"{context.RedirectUri}&hd={Configuration["AuthenticationData:Google:OrganizationName"]}");
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

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

            if (!_env.IsDevelopment())
            {
                var context = (ApplicationDbContext)app.ApplicationServices.GetService(typeof(ApplicationDbContext));
                context.Database.Migrate();
            }
            
            ApplicationDbSeed.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
            ApplicationDbSeed.EnsureSeeded(app.ApplicationServices, Configuration);
        }
    }
}