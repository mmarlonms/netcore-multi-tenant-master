using MultiTenantCore.Domain.Model;
using System.Collections.Generic;

namespace MultiTenantCore.Domain.Interface
{
    public interface IAlunoService
    {
        IEnumerable<Aluno> GetAlunos(string tenantName);
    }
}
