using SaasKit.Multitenancy.StructureMap;
using StructureMap;
using System.Threading.Tasks;
using MultiTenantCore.Domain.Interface;
using MultiTenantCore.Service.Alunos.Default;
using MultiTenantCore.Service.Alunos.Outro;

namespace AspNetStructureMapSample
{
    public class AppTenantContainerBuilder : ITenantContainerBuilder<AppTenant>
    {
        private IContainer container;

        public AppTenantContainerBuilder(IContainer container)
        {
            this.container = container;
        }

        public Task<IContainer> BuildAsync(AppTenant tenant)
        {
            var tenantContainer = container.CreateChildContainer();
            tenantContainer.Configure(config =>
            {
                if (tenant.Name == "Outro")
                {
                    config.ForSingletonOf<IAlunoService>().Use<OutroAlunoService>();
                }
                else
                {
                    config.ForSingletonOf<IAlunoService>().Use<AlunoService>();
                }
            });

            return Task.FromResult(tenantContainer);
        }
    }
}
