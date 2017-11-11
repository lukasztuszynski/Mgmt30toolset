using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Mgmt30toolset.Models;
using Mgmt30toolset.Models.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration["Data:Mgmt30toolset:ConnectionString"]));
            services.AddTransient<IKudoRepository, KudoRepository>();
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
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "pagination",
                        template: "Kudo/Page{pageNumber}",
                        defaults: new { Controller = "Kudo", action = "Index" });

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Kudo}/{action=Index}/{id?}");
                });
                ApplicationDbSeed.EnsurePopulated(app);
            }
        }
    }
}
