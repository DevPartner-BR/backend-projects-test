using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using CrudWebAPIAspCore.Model;
using CrudWebAPIAspCore.Service;
using Microsoft.AspNetCore.Diagnostics;

namespace CrudWebAPIAspCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INFService, NFService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    var ex = context.Features
                                    .Get<IExceptionHandlerFeature>()
                                    .Error;

                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync($"{ex.Message}");
                });
            });
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
