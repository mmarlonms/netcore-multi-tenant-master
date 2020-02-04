using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MultiTenantCore.Domain.Interface;
using MultiTenantCore.Domain.Model;
using SaasKit.Multitenancy;
using AspNetStructureMapSample;

namespace MultiTenantCore.Controllers
{
    [ApiController]
    [Route("Aluno")]
    public class AlunoController : ControllerBase
    {
        public AlunoController(IAlunoService contratanetAluno, ITenant<AppTenant> tenant)
        {
            ContratanetAluno = contratanetAluno;
            Tenant = tenant;
        }

        public IAlunoService ContratanetAluno { get; }
        public ITenant<AppTenant> Tenant { get; }

        [HttpGet("GetAlunos")]
        public IEnumerable<Aluno> Get()
        {
            return ContratanetAluno.GetAlunos(Tenant.Value.Name);
        }
    }
}