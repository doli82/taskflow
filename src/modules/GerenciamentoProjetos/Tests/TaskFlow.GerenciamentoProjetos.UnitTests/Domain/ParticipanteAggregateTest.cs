using TaskFlow.GerenciamentoProjetos.Domain.Equipes;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using TaskFlow.GerenciamentoProjetos.Domain.Participantes;
using TaskFlow.GerenciamentoProjetos.Domain.Projetos;
using Xunit;

namespace TaskFlow.GerenciamentoProjetos.UnitTests.Domain
{
	public class ParticipanteAggregateTest
    {

        [Fact]
        public void Deve_criar_um_participante()
        {
            //Arrange
            int usuarioId = 10;
            string usuarioNome = "Daniel Oliveira";

            //Act
            var participante = new Participante(usuarioId, usuarioNome);

            //Assert
            Assert.NotNull(participante);
        }

        [Fact]
        public void Deve_adicionar_um_participante_a_um_projeto()
        {
            //Arrange
            int usuarioId = 10;
            string usuarioNome = "Daniel Oliveira";
            var projeto = new Projeto("Projeto Teste", "Testando título do fluxo de trabalho");

            //Act
            var participante = new Participante(usuarioId, usuarioNome);
            projeto.AdicionarParticipante(participante);

            //Assert
            Assert.Equal(1, projeto.Participantes.Count);
        }

        [Fact]
        public void Deve_adicionar_um_participante_a_dois_projetos()
        {
            //Arrange
            var participante = new Participante(10, "Daniel Oliveira");
            var projeto1 = new Projeto("Projeto1 de Teste", "Testando título do projeto 1");
            var projeto2 = new Projeto("Projeto2 de Teste", "Testando título do projeto 2");

            //Act
            projeto1.AdicionarParticipante(participante);
            projeto2.AdicionarParticipante(participante);

            //Assert
            Assert.Equal(1, projeto1.Participantes.Count);
            Assert.Equal(1, projeto2.Participantes.Count);
        }

        [Fact]
        public void Deve_adicionar_um_participante_a_uma_equipe()
        {
            //Arrange
            int usuarioId = 10;
            string usuarioNome = "Daniel Oliveira";
            var equipe = new Equipe();

            //Act
            var participante = new Participante(usuarioId, usuarioNome);
            equipe.AdicionarParticipante(participante);

            //Assert
            Assert.Equal(1, equipe.Participantes.Count);
        }


        [Fact]
        public void Deve_falhar_ao_adicionar_um_participante_a_uma_equipe_mais_de_uma_vez()
        {
            //Arrange
            int usuarioId = 10;
            string usuarioNome = "Daniel Oliveira";
            var equipe = new Equipe();

            //Act
            var participante_instancia1 = new Participante(usuarioId, usuarioNome);
            var participante_instancia2 = new Participante(usuarioId, usuarioNome);
            equipe.AdicionarParticipante(participante_instancia1);

            //Act - Assert
            Assert.Throws<EquipeDomainException>(() => equipe.AdicionarParticipante(participante_instancia2));
        }

        [Fact]
        public void Deve_adicionar_um_participante_a_duas_equipes()
        {
            //Arrange
            var participante = new Participante(10, "Daniel Oliveira");
            var equipe1 = new Equipe();
            var equipe2 = new Equipe();

            //Act
            equipe1.AdicionarParticipante(participante);
            equipe2.AdicionarParticipante(participante);

            //Assert
            Assert.Equal(1, equipe1.Participantes.Count);
            Assert.Equal(1, equipe2.Participantes.Count);
        }
    }
}
