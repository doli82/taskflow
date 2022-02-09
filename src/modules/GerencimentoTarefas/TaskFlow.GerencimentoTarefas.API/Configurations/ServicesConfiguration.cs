using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TaskFlow.GerencimentoTarefas.Infrastructure.DbContexts;
using TaskFlow.GerenciamentoTarefas.Domain.Repositories;
using TaskFlow.GerencimentoTarefas.Infrastructure.Repositories;

namespace TaskFlow.GerencimentoTarefas.API.Configurations
{
	public static class ServicesConfiguration
    {
        public static void AddServiceConfigurations(this IServiceCollection services)
        {
            string connectionString = "server=localhost;database=taskflow;uid=root;pwd=GH#@Mn47spW!HH$yvv76";

            services.AddDbContext<GerenciamentoTarefasContext>(opt =>
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
               .UseSnakeCaseNamingConvention()
            );

            services.AddScoped<ITarefaRepository, TarefaRepository>();
        }
    }
}
