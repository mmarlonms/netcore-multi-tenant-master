using System.Collections.Generic;
using MultiTenantCore.Domain.Model;

namespace MultiTenantCore.Domain.Interface
{
    public interface IAlunoService
    {
        IEnumerable<Aluno> GetAlunos(string tenantName);
    }
}
