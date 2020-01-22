using System.Collections.Generic;
using MultiTenantCore.Domain.Model.Default;

namespace MultiTenantCore.Domain.Interface
{
    public interface IAlunoService
    {
        IEnumerable<Aluno> GetAlunos();
    }
}
