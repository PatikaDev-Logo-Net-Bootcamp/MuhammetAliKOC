using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02_Middlewares_Swaggers.Filters
{
    public class SwaggerOperationFilter : IOperationFilter
    {
        private readonly IConfiguration _configuration;
        public SwaggerOperationFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "app-version",
                In = ParameterLocation.Header,
                Description = "Api version is here.",
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString(_configuration.GetSection("api-version").Value.ToString())/*appsetting.json içindeki değeri koyuyoruz.*/
                }
            });
        }
    }
}
