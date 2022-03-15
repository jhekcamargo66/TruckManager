using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TruckManager.Core;
using TruckManager.Repository;

namespace TruckManager
{
    public class Startup
    {
        private IConfiguration configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<Context>();
            services.AddScoped<ITruckManagerService, TruckManagerService>();
            services.AddScoped<ITruckModelRepository, TruckModelRepository>();
            services.AddResponseCaching();
            services.AddOptions();
            services.AddHttpClient();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc(Assembly.GetExecutingAssembly().GetName().Version?.ToString(),
            //        new Microsoft.OpenApi.Models.OpenApiInfo { Title = nameof(TruckManager), Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() });
            //});
        }

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint($"/swagger/{Assembly.GetExecutingAssembly().GetName().Version?.ToString()}/swagger.json", nameof(TruckManager));
            //    c.SupportedSubmitMethods(new Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod[] { });
            //});
        }
    }
}
