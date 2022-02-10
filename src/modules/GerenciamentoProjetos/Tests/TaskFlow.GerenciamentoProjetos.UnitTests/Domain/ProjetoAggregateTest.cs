using System;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using TaskFlow.GerenciamentoProjetos.Domain.Projetos;
using Xunit;

namespace TaskFlow.GerenciamentoProjetos.UnitTests.Domain
{
	public class ProjetoAggregateTest
	{

        [Fact]
        public void Deve_criar_um_projeto()
        {
            //Arrange
            var nomeProjeto = "Projeto de teste";
            var descricao = "Descrição do Projeto de teste";

            //Act 
            var projeto = new Projeto(nomeProjeto, descricao);

            //Assert
            Assert.NotNull(projeto);
        }


        [Fact]
        public void Deve_conter_titulo_em_um_novo_projeto()
        {
            //Arrange
            var nomeProjeto = "Projeto de teste";
            var descricao = "Descrição do Projeto de teste";
            var projeto1 = new Projeto(nomeProjeto, descricao);

            //Act - Assert
            Assert.Equal(projeto1.Titulo, nomeProjeto);
            Assert.Throws<ProjetoDomainException>(() => new Projeto(null, descricao));
            Assert.Throws<ProjetoDomainException>(() => new Projeto("", descricao));
        }

        [Fact]
        public void Deve_conter_descricao_em_um_novo_projeto()
        {
            //Arrange
            var nomeProjeto = "Projeto de teste";
            var descricao = "Descrição do projeto de teste";
            var projeto1 = new Projeto(nomeProjeto, descricao);

            //Act - Assert
            Assert.Equal(projeto1.Titulo, nomeProjeto);
            Assert.Throws<ProjetoDomainException>(() => new Projeto("Projeto 01", null));
            Assert.Throws<ProjetoDomainException>(() => new Projeto("Projeto 02", ""));
        }

        [Fact]
        public void Deve_adicionar_varios_fluxos_trabalho_ao_projeto()
        {
            //Arrange
            var fluxoTrabalho1Nome = "Para Fazer";
            var fluxoTrabalho2Nome = "Em Andamento";
            var fluxoTrabalho3Nome = "Revisão de Código";
            var projeto = new Projeto("Projeto de teste", "Descrição do projeto de teste");

            //Act 
            projeto.AdicionarFluxoTrabalho(fluxoTrabalho1Nome);
            projeto.AdicionarFluxoTrabalho(fluxoTrabalho2Nome);
            projeto.AdicionarFluxoTrabalho(fluxoTrabalho3Nome);

            //Assert
            Assert.Equal(3, projeto.FluxosTrabalho.Count);
        }

        [Fact]
        public void Deve_adicionar_data_de_inicio_a_um_projeto()
        {
            //Arrange
            DateTime dataInicioProjeto = DateTime.Parse("1982-09-14 13:32:00");
            var projeto = new Projeto("Projeto de teste", "Descrição do projeto de teste");

            //Act 
            projeto.DefinirDataInicio(dataInicioProjeto);

            //Assert
            Assert.Equal(dataInicioProjeto, projeto.DataInicio);
        }
    }
}
