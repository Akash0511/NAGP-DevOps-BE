using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NagpDevOpsApp.Config;
using NagpDevOpsApp.Models;
using NagpDevOpsApp.Repositories;
using NagpDevOpsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NagpDevOpsApp
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
            //services.Configure<ProductDatabaseSettings>(
            //    Configuration.GetSection(nameof(ProductDatabaseSettings)));

            //services.AddSingleton<IProductDatabaseSettings>(sp =>
            //    sp.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value);

            //services.AddSingleton<ProductService>();

            var config = new ServerConfig();
            Configuration.Bind(config);

            var productContext = new ProductContext(config.MongoDB);
            var repo = new ProductRepository(productContext);

            services.AddSingleton<IProductRepository>(repo);


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
