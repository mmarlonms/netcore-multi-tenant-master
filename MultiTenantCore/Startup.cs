using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonteOlimpo.Base.ApiBoot;
using MultiTenantCore.Service.Alunos;
using System.Collections.Generic;
using System.Reflection;

namespace MultiTenantCore
{
    public class Startup : MonteOlimpoBootStrap
    {
        public Startup(IConfiguration configuration)
             : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMultitenancy<Portal, PortalResolver>();
            base.ConfigureServices(services);
        }


        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMultitenancy<Portal>();

            base.Configure(app, env);
        }

        protected override IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(AlunoService).Assembly;
        }

    }
}
