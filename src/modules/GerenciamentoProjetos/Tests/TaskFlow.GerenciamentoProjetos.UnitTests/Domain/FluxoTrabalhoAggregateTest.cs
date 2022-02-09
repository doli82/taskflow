using System;
using System.Linq;
using TaskFlow.GerenciamentoProjetos.Domain;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using Xunit;

namespace TaskFlow.GerenciamentoProjetos.UnitTests.Domain
{
	public class FluxoTrabalhoAggregateTest
	{
		public FluxoTrabalhoAggregateTest()
		{
		}

		[Fact]
        public void Deve_criar_um_fluxo_de_trabalho()
        {
            //Arrange
            var titulo = "Novo fluxo de trabalho";

            //Act 
            var fluxoTrabalho = new FluxoTrabalho(titulo);

            //Assert
            Assert.NotNull(fluxoTrabalho);
        }

        [Fact]
        public void Deve_conter_um_titulo_no_novo_fluxo_de_trabalho()
        {
            //Arrange
            string tituloCorreto = "Novo Fluxo de Trabalho";
            var tituloVazio = "";
            string tituloNulo = null;

            //Act
            var fluxoTrabalho = new FluxoTrabalho(tituloCorreto);
            
            //Assert
            Assert.Equal(fluxoTrabalho.Titulo, tituloCorreto);
            //Act - Assert
            Assert.Throws<FluxoTrabalhoDomainException>(() => new FluxoTrabalho(tituloVazio));
            Assert.Throws<FluxoTrabalhoDomainException>(() => new FluxoTrabalho(tituloNulo));
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
            var fluxoTrabalho = new FluxoTrabalho(titulo);

            // Act
            fluxoTrabalho.AdicionarEstado(estado1Titulo, estado1Descricao);
            fluxoTrabalho.AdicionarEstado(estado2Titulo, estado2Descricao);

            //Assert
            Assert.Equal(2, fluxoTrabalho.Estados.Count());
        }

        [Fact]
        public void Deve_conter_um_titulo_nos_novos_estados_dos_fluxos_de_trabalho()
        {
            //Arrange
            var titulo = "Fluxo de Teste";
            string estado1Titulo = null;
            string estado1Descricao = "Trabalho que não foi iniciado";
            string estado2Titulo = "";
            var fluxoTrabalho = new FluxoTrabalho(titulo);

            //Act - Assert
            Assert.Throws<FluxoTrabalhoDomainException>(() => fluxoTrabalho.AdicionarEstado(estado1Titulo, estado1Descricao));
            Assert.Throws<FluxoTrabalhoDomainException>(() => fluxoTrabalho.AdicionarEstado(estado2Titulo));
        }
    }
}
