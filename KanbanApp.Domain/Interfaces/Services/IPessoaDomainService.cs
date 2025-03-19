using KanbanApp.Domain.Dtos.Requests;
using KanbanApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApp.Domain.Interfaces.Services
{
    public interface IPessoaDomainService
    {
        CriarPessoaResponse Criar(CriarPessoaRequest request);

        AutenticarPessoaResponse Autenticar(AutenticarPessoaRequest request);
    }
}
