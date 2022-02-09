using System.Linq;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using TaskFlow.GerenciamentoProjetos.Domain.Projeto;
using Xunit;

namespace TaskFlow.GerenciamentoProjetos.UnitTests.Domain
{
	public class FluxoTrabalhoAggregateTest
	{
		public FluxoTrabalhoAggregateTest()
		{
		}

        [Fact]
        public void Deve_conter_titulo_o_novo_fluxo_de_trabalho()
        {
            //Arrange
            string tituloCorreto = "Novo Fluxo de Trabalho";
            var tituloVazio = "";
            string tituloNulo = null;
            var projeto = new Projeto("Projeto Teste", "Testando título do fluxo de trabalho");  

            //Act
            projeto.AdicionarFluxoTrabalho(tituloCorreto);            

            //Assert
            Assert.Equal(tituloCorreto, projeto.FluxosTrabalho.First().Titulo);

            //Act - Assert
            Assert.Throws<FluxoTrabalhoDomainException>(() => projeto.AdicionarFluxoTrabalho(tituloVazio));
            Assert.Throws<FluxoTrabalhoDomainException>(() => projeto.AdicionarFluxoTrabalho(tituloNulo));
        }

        [Fact]
        public void Deve_conseguir_adicionar_estados_ao_fluxo_novo_fluxo_de_trabalho()
        {
            //Arrange
            var titulo = "Fluxo de Teste";
            string estado1Titulo = "Para Fazer";
            string estado1Descricao = "Trabalho que não foi iniciado";
            string estado2Titulo = "Em Andamento";
            string estado2Descricao = "Trabalho que está sendo feito pela equipe";

            var projeto = new Projeto("Projeto Teste", "Testando título do fluxo de trabalho");
            projeto.AdicionarFluxoTrabalho(titulo);
            var fluxoTrabalho = projeto.FluxosTrabalho.First();

            // Act
            fluxoTrabalho.AdicionarEstado(estado1Titulo, estado1Descricao);
            fluxoTrabalho.AdicionarEstado(estado2Titulo, estado2Descricao);

            //Assert
            Assert.Equal(2, fluxoTrabalho.Estados.Count());
        }

        [Fact]
        public void Deve_conter_titulo_o_novo_estado_do_fluxo_de_trabalho()
        {
            //Arrange
            var titulo = "Fluxo de Teste";
            string estadoTitulo = "Revisão de Código";
            string estadoDescricao = "Trabalho que não foi iniciado";
            var projeto = new Projeto("Projeto Teste", "Testando título do fluxo de trabalho");
            projeto.AdicionarFluxoTrabalho(titulo);
            var fluxoTrabalho = projeto.FluxosTrabalho.First();
            fluxoTrabalho.AdicionarEstado(estadoTitulo, estadoDescricao);

            //Act - Assert
            Assert.Equal(estadoTitulo , fluxoTrabalho.Estados.First().Titulo);
            Assert.Throws<FluxoTrabalhoDomainException>(() => fluxoTrabalho.AdicionarEstado(null, estadoDescricao));
        }
    }
}
