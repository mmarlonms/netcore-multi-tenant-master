using System.Collections.Generic;
using MultiTenantCore.Domain.Interface;
using MultiTenantCore.Domain.Model.Default;

namespace MultiTenantCore.Service.Alunos.Default
{
    public class AlunoService : IAlunoService
    {
        public virtual IEnumerable<Aluno> GetAlunos()
        {
            return new List<Aluno> { new Aluno() { Idade = 10, Nome = "Aluno 2" }, new Aluno() { Nome = "Aluno 1", Idade = 15 } };
        }
    }
}
