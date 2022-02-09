using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using TaskFlow.GerenciamentoProjetos.Domain.Projeto;
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
            Assert.Throws<ProjetoDomainException>(() => new Projeto("Projeto 02",""));
        }
    }
}
