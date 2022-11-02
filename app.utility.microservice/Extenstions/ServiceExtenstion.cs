using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.Extenstions
{
    public static class ServiceExtenstion
    {
        /// <summary>
        /// To Support Cross Origin Resource Common Liabrary API
        /// </summary>
        /// <param name="services"></param>
        /// <param name="corsTitle"></param>
        public static void ConfigureCorsSetup(this IServiceCollection services, string corsTitle)
        {
            services.AddCors(options => options.AddPolicy(corsTitle, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        /// <summary>
        /// To Configure Swagger For Common Liabrary API
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerTitle"></param>
        public static void ConfigureSwaggerSetup(this IServiceCollection services, string swaggerTitle)
        {
            services.AddSwaggerGen(c =>
            {
                //Set Titile Of Swagger
                c.SwaggerDoc("v1", new OpenApiInfo { Title = swaggerTitle, Version = "v1" });

                //Set Header Autorize Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                //Set And Configure JWT
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
        }
    }
}
