using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCobros.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace AppCobros
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //cntiene los mismos nombres de las entidades
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(op =>
                {
                    var resolver = op.SerializerSettings.ContractResolver;
                    if (resolver != null)
                    {
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                        op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    }
                });/*
            services.AddMvc()
                    .AddJsonOptions(
                        options => options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );*/
            //DB
            services.AddDbContext<PaymentDetailContext>(op =>
            {
                op.UseSqlServer(Configuration.GetConnectionString("Pagos"));
            });
            //cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //cos
            app.UseCors(builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
            app.UseMvc();
           
        }
    }
}
