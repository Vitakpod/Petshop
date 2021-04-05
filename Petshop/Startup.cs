using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Petshop.DAL.Context;
using Petshop.DAL.Interfaces;
using Petshop.DAL.Repositories;
using Petshop.BLL.Interfaces;
using Petshop.BLL.Services;

namespace Petshop
{
        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                string connection = Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<PetContext>(options => options.UseSqlServer(connection));
                services.AddMvc();
                services.AddControllers();
                services.AddScoped<IUnitOfWork, ShopUnitOfWork>();
                services.AddScoped<IShopService, ShopService>();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Main}/{action=Index}");
                });
            }
        }

}
