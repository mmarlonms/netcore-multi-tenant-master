using System.Collections.Generic;
using MultiTenantCore.Domain.Interface;
using MultiTenantCore.Domain.Model;

namespace MultiTenantCore.Service.Alunos
{
    public class AlunoService : IAlunoService
    {
        public virtual IEnumerable<Aluno> GetAlunos(string tenantName)
        {
            return new List<Aluno> { new Aluno() { Idade = 10, Nome = "Aluno 2", TenantName = tenantName }, new Aluno() { Nome = "Aluno 1", Idade = 15, TenantName = tenantName } };
        }
    }
}
