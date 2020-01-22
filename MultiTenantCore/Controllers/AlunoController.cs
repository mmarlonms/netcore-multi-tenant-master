using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MultiTenantCore.Domain.Interface;
using MultiTenantCore.Domain.Model.Default;

namespace MultiTenantCore.Controllers
{
    [ApiController]
    [Route("Aluno")]
    public class AlunoController : ControllerBase
    {
        public AlunoController(IAlunoService contratanetAluno)
        {
            ContratanetAluno = contratanetAluno;
        }

        public IAlunoService ContratanetAluno { get; }

        [HttpGet("GetAlunos")]
        public IEnumerable<Aluno> Get()
        {
            return ContratanetAluno.GetAlunos();
        }
    }
}