using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace app.utility.microservice.Extenstions
{
    public static class ApplicationBuilderExtension
    {
        public static void SwaggerDeplomentAndLocalSetup(this IApplicationBuilder app, IWebHostEnvironment env, string swaggerTitleAndVersion, string deploymentApplicationPrefix)
        {
            app.UseSwaggerUI(c =>
            {
                if (env.IsDevelopment())
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerTitleAndVersion);
                }
                else
                {
                    c.SwaggerEndpoint("/" + deploymentApplicationPrefix + "/swagger/v1/swagger.json", swaggerTitleAndVersion);
                }
            });
        }
    }
}
