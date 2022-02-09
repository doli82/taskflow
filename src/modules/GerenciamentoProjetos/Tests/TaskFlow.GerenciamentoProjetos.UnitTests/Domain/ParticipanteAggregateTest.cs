using TaskFlow.GerenciamentoProjetos.Domain.Projetos;
using Xunit;

namespace TaskFlow.GerenciamentoProjetos.UnitTests.Domain
{
	public class ParticipanteAggregateTest
    {

        [Fact]
        public void Deve_adicionar_um_participante_a_um_projeto()
        {
            //Arrange
            int usuarioId = 10;
            var projeto = new Projeto("Projeto Teste", "Testando título do fluxo de trabalho");

            //Act
            projeto.AdicionarParticipante(usuarioId);

            //Assert
            Assert.Equal(1, projeto.Participantes.Count);
        }
    }
}
