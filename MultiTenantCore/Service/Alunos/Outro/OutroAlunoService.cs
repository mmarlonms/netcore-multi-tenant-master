using System.Collections.Generic;
using MultiTenantCore.Domain.Model.Default;
using MultiTenantCore.Service.Alunos.Default;

namespace MultiTenantCore.Service.Alunos.Outro
{
    public class OutroAlunoService : AlunoService
    {
        public override IEnumerable<Aluno> GetAlunos()
        {
            var list2 = new List<OutroAluno> { new OutroAluno() { Idade = 10, Nome = "Aluno OUTRO 2", FiscalCode = "AJSBD" }, new OutroAluno() { Nome = "Aluno OUTRO 1", Idade = 15, FiscalCode = "ASIDJ" } };
            return list2;
        }
    }
}