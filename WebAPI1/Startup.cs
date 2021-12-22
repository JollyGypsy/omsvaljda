using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI1.Data;

namespace WebAPI1
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
            services.AddDbContext<PhoneBookContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("PhoneBookConn")));

            services.AddControllers();
            services.AddSwaggerGen();
            /*services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "[anything]", Version = "v1" });
                c.AddSecurityDefinition("[auth scheme: same name as defined for asp.net]", new ApiKeyScheme()
                {
                    In = ParameterLocation.Header,
                    Name = "X-API-KEY", //header with api key
                    Type = SecuritySchemeType.ApiKey,
                });
            });
            */

            //services.AddSwaggerDocumentation();
            services.AddScoped<IPersonRepo, SqlContactRepo>();
            
        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI1 v1"));
               // app.UseSwaggerDocumentation();
            }
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseMiddleware<ApiKeyMiddleware>();

        }
    }
}

