using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterdimensionalThings.Data;
using InterdimensionalThings.Models;
using InterdimensionalThings.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Pomelo.EntityFrameworkCore.MySql;
namespace InterdimensionalThings
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseMySql("Server=127.0.0.1;uid=root;password=password;database=ThingDatabase"));

            services.AddIdentity<ApplicationUser, ApplicationRole>(
            identity =>
            {
                // whatever identity options you want
                identity.User.RequireUniqueEmail = true;
                identity.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddSingleton<SettingsService>();

            services.AddTransient<MySqlConnection>((x) => new MySqlConnection(Configuration.GetConnectionString("NewConnection")));
           
             services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
