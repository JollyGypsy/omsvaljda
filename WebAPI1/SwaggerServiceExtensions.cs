using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;

namespace WebAPI1
{
    public static class SwaggerServiceExtensions
    {
        /*public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Main API v1.0", Version = "v1.0" });
                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(new OpenApiSecurityScheme(), new string[] { });
                c.AddSecurityDefinition("[auth scheme: same name as defined for asp.net]", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Name = "X-API-KEY", //header with api key
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(securityRequirement);
            });
            return services;
        }*/
       /* public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");
                c.DocumentTitle = "Title Documentation";
                c.DocExpansion(DocExpansion.None);
            });
            return app;
        }*/
    }
}
