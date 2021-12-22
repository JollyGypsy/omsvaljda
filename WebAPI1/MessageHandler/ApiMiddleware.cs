using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI1.MessageHandler
{
    public class ApiMiddleware:DelegatingHandler
    {
        private const string apiKeyToCheck = "10e357984b5596626dd74ea4b40bc2d6fc685174d735d35dd90a5c36ae21c415";
        /* protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage msg, CancellationToken cancellationToken)
         {
             bool isValid = false;
             IEnumerable<string> requestHeaders;
             var checkApiExists = msg.Headers.TryGetValues("API_KEY", out requestHeaders);
             if (checkApiExists)
             {
                 if (requestHeaders.FirstOrDefault().Equals(apiKeyToCheck))
                 {
                     isValid= true;
                 }
             }
             if (!checkApiExists)
             {

                 return msg.CreateResponse(HttpStatusCode.Forbidden);

             }
             var response = await base.SendAsync(msg, cancellationToken);
             return response;
         }*/
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        public ApiMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided. (Using ApiKeyMiddleware) ");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

            var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");
                return;
            }

            await _next(context);
        }
    }
}
