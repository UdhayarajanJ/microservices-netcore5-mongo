using app.recruiter.api.IRepository;
using app.recruiter.api.Repository;
using app.utility.microservice.Extenstions;
using app.utility.microservice.IRepository;
using app.utility.microservice.Models;
using app.utility.microservice.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace app.recruiter.api
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

            //To Config Cross Origin Support
            services.ConfigureCorsSetup("Recruiter");

            //To Config Swagger Globally
            services.ConfigureSwaggerSetup("Recruiter Application Programming Interface");

            //To Utility Microservice Dependency
            services.AddSingleton<MongoDatabaseConfiguration>(Configuration.GetSection("MongoDBConfiguration").Get<MongoDatabaseConfiguration>());
            services.AddTransient<IMongoDataContext, MongoDataContext>();

            //To Api Application Dependency
            services.AddTransient<IJobRolesRepository, JobRolesRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            app.UseSwagger();

            //Swagger Setup Deployment And Local Setup
            app.SwaggerDeplomentAndLocalSetup(env, "Recruiter Backend Application Version - 1","RecruiterApp");
            
            //
            app.UseCors("Recruiter");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
