using Microsoft.AspNetCore.Mvc;
using MonteOlimpo.Base.ApiBoot;
using MultiTenantCore.Domain.Interface;
using MultiTenantCore.Domain.Model;
using SaasKit.Multitenancy;
using System.Collections.Generic;

namespace MultiTenantCore.Controllers
{
    
    [Route("Aluno")]
    public class AlunoController : ApiBaseController
    {
        public IAlunoService ContratanetAluno { get; }

        public AlunoController(IAlunoService contratanetAluno)
        {
            ContratanetAluno = contratanetAluno;
        }

        [HttpGet("GetAlunos")]
        public IEnumerable<Aluno> Get([FromServices] ITenant<Portal> tenant)
        {
  
            return ContratanetAluno.GetAlunos(tenant.Value.Name);
        }
    }
}