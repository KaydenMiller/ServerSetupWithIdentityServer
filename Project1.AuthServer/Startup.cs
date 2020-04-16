using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project1.Data.DataAccess.DependencyInjection;
using Project1.Shared.Data.Identity.Entities;

namespace Project1.AuthServer
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationDataContext(_configuration);

            //TODO: Alter this so they are no longer in memory resources before pushing to production
            var builder = services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                })
                .AddInMemoryIdentityResources(Config.Ids)
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<ApplicationUserEntity>();

            // TODO: This signing credential needs to be updated to a production credential when not in development
            builder.AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            
            // uncomment if you want to add MVC
            // app.UseStaticFiles();
            // app.UseRouting();

            app.UseIdentityServer();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            // });
        }
    }
}