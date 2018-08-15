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
using Braintree;

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

            //Use this for the mysql database:
            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
           
            ////Use this for in memory database like for publishing to azure for demos
            //services.AddDbContext<ApplicationDbContext>(options =>
                                                        //options.UseInMemoryDatabase("Default"));
           

            services.AddIdentity<ApplicationUser, ApplicationRole>(
            identity =>
            {
                // whatever identity options you want
                identity.User.RequireUniqueEmail = true;
                identity.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender>((iSP) => new EmailSender(Configuration.GetValue<string>("SendGrid.ApiKey")));
          
            services.AddTransient<Braintree.IBraintreeGateway>((iServiceProvider) => new Braintree.BraintreeGateway(
                Configuration.GetValue<string>("Environment"),
                Configuration.GetValue<string>("MerchantId"),
                Configuration.GetValue<string>("PublicKey"),
                Configuration.GetValue<string>("PrivateKey")
                ));

            services.AddTransient<SmartyStreets.USStreetApi.Client>((iSP) =>
{
    SmartyStreets.ClientBuilder clientBuilder = new SmartyStreets.ClientBuilder(
        Configuration.GetValue<string>("SmartyStreets.AuthId"),
        Configuration.GetValue<string>("SmartyStreets.AuthToken")
    );
    return clientBuilder.BuildUsStreetApiClient();
});                                  
            services.AddSingleton<SettingsService>();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new Microsoft.AspNetCore.Mvc.RequireHttpsAttribute());
            //});
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
