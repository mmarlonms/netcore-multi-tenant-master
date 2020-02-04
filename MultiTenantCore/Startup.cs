using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MonteOlimpo.Base.Extensions.Service;
using MonteOlimpo.Base.Filters.Exceptions;
using MonteOlimpo.Base.Filters.Validation;
using SaasKit.Multitenancy.StructureMap;
using StructureMap;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AspNetStructureMapSample
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {


            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                //options.Filters.Add<ExceptionFilter>();
                //options.Filters.Add<ValidatorActionFilter>();

            });
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //  .ConfigureApiBehaviorOptions(options =>
            //  {
            //      options.SuppressModelStateInvalidFilter = true;
            //  })
            //.AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblies(this.GetValidationAssemblies()));

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMonteOlimpoLogging(Configuration);
            //services.AddExceptionHandling();
            //services.AddValidationHandling();
            services.AddMonteOlimpoSwagger(Configuration);
            services.RegisterAllTypes(GetAditionalAssemblies());

            services.AddMultitenancy<AppTenant, AppTenantResolver>();

            var container = new Container();
            services.AddControllers();
            container.Populate(services);


            container.Configure(c =>
            {
                c.For<ITenantContainerBuilder<AppTenant>>().Use(() => new AppTenantContainerBuilder(container));
                
            });



            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMultitenancy<AppTenant>();
            app.UseTenantContainers<AppTenant>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMonteOlimpoSwagger();
        }

        protected virtual IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(Startup).Assembly;
        }

        protected virtual IEnumerable<Assembly> GetValidationAssemblies()
        {
            yield return typeof(Startup).Assembly;
        }

       
    }
}
