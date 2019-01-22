using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Database
            // [note] Registering DbContext to communicate with SQL Server
            services
                .AddDbContext<AppDbContext>(builder =>
                {
                    builder.UseSqlServer(Configuration.GetConnectionString("DevPartnerNotaFiscal"));
                });
            #endregion

            #region AutoMapper
            Mapper.Initialize(config =>
            {
                config.CreateMap<NotaFiscalCreate, NotaFiscal>();
                config.CreateMap<NotaFiscalUpdate, NotaFiscal>();
                config.CreateMap<NotaFiscal, NotaFiscalList>();
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
