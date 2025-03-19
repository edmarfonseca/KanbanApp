using KanbanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApp.Domain.Interfaces.Security
{
    public interface ITokenSecurity
    {
        string CreateToken(Guid pessoaId);

        DateTime GetExpirationDate();
    }
}
