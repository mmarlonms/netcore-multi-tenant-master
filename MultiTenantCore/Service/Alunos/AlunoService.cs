using MultiTenantCore.Domain.Interface;
using MultiTenantCore.Domain.Model;
using System.Collections.Generic;

namespace MultiTenantCore.Service.Alunos
{
    public class AlunoService : IAlunoService
    {
        public virtual IEnumerable<Aluno> GetAlunos(string tenantName)
        {
            return new List<Aluno> { new Aluno() { Idade = 10, Nome = "Aluno 2", PortalName = tenantName }, new Aluno() { Nome = "Aluno 1", Idade = 15, PortalName = tenantName } };
        }
    }
}
