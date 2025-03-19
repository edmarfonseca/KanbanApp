using KanbanApp.Domain.Interfaces.Repositories;
using KanbanApp.Domain.Interfaces.Security;
using KanbanApp.Domain.Interfaces.Services;
using KanbanApp.Domain.Services;
using KanbanApp.Infra.Data.Repositories;
using KanbanApp.Infra.Security.Services;

namespace KanbanApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração para as injeções de dependência do projeto.
    /// </summary>
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IPessoaDomainService, PessoaDomainService>();
            services.AddTransient<ITarefaDomainService, TarefaDomainService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<ITokenSecurity, TokenSecurity>();
        }
    }
}
