using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;

namespace TaskFlow.GerencimentoTarefas.Infrastructure.DbContexts.Mappings
{
	public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tarefa");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Titulo)
                   .HasMaxLength(300);

            builder.Property(p => p.Descricao)
                   .HasMaxLength(500);
        }
    }
}
