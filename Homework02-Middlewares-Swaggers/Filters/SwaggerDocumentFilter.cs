using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02_Middlewares_Swaggers.Filters
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        private IServiceProvider _provider;

        public SwaggerDocumentFilter(IServiceProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            this._provider = provider;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //hide isimli action burada gizleniyor.
            var route = "/api/Home/Hide";
            swaggerDoc.Paths.Remove(route);       
        }


    }
}
