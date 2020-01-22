using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SaasKit.Multitenancy.StructureMap;
using StructureMap;
using System;

namespace AspNetStructureMapSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
