using ChipIn.Services.DbManagers;
using ChipIn.Services.DbManagers.ServicesInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ChipIn
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSingleton<IDatabaseConnectionService>(new DatabaseConnectionService("mongodb://localhost:27017/ChipIn"));

            services.AddSingleton(provider => 
                new UsersManagerService(provider.GetRequiredService<IDatabaseConnectionService>(), "Users"));

            services.AddSingleton(provider =>
                new GroupsManagerService(provider.GetRequiredService<IDatabaseConnectionService>(), "Groups"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
