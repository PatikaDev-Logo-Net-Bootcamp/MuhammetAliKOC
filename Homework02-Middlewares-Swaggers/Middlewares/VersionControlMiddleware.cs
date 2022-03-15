using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02_Middlewares_Swaggers.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class VersionControlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _version;

        public VersionControlMiddleware(RequestDelegate next, string version)
        {
            _next = next;
            _version = version;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            
            //request login yada register ise bir sonraki pipeline a geçsin.
            if (httpContext.Request.Path.Value.ToLower().Contains("login") || httpContext.Request.Path.Value.ToLower().Contains("register"))
            {
                await _next(httpContext);
            }
            else//Login ve register
            {
                httpContext.Request.Headers.TryGetValue("app-version", out var requestVersion);
                try
                {
                    /*Versiyon kontrolü burada yapılıyor. Eğer requestte gelen versiyon appsetting.json da tanımlanmış versiyondan büyüksü 401 statuscode gönder. Bir sonraki middleware a geçme!*/

                    var versionRequest = new Version(requestVersion.ToString());
                    var versionApi = new Version(_version);
                    var result = versionRequest.CompareTo(versionApi);
                    if (result > 0)// versionRequest is greater
                    {
                        httpContext.Response.StatusCode = 401; //Unauthorized         
                        await httpContext.Response.WriteAsync("version not compatible!");
                        return;
                    }
                }
                catch (Exception ex)//hata alınırsa kullanıcıya sunucu içi hata olarak bilgi gitsin.
                {
                    httpContext.Response.StatusCode = 500; //Server Error         
                    await httpContext.Response.WriteAsync("Unexpected Error!");
                    return;
                }

                await _next(httpContext);
            }

           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class VersionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseVersionControlMiddleware(this IApplicationBuilder builder, string version)
        {
            return builder.UseMiddleware<VersionControlMiddleware>(version);
        }
    }
}
