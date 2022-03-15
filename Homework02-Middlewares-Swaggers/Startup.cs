using Homework02_Middlewares_Swaggers.Filters;
using Homework02_Middlewares_Swaggers.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Homework02_Middlewares_Swaggers
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Homework02_Middlewares_Swaggers", Version = "v1" });

                /*Swaggerda kullanýlacak filtrelemeler burada yapýlýyor.*/
                c.DocumentFilter<SwaggerDocumentFilter>();

                /*Swagger header a api versiyon burada yapýlýyor.*/
                c.OperationFilter<SwaggerOperationFilter>();


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Homework02_Middlewares_Swaggers_v1"));
            }

            /*Api versiyon kontrolü burada yapýlýyor.*/
            var app_version = Configuration.GetSection("api-version").Value.ToString();
            app.UseVersionControlMiddleware(app_version);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
