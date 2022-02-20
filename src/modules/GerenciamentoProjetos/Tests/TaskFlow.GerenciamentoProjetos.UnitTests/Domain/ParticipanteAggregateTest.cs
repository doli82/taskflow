using System.Collections.Generic;
using System.Linq;
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
            string nomeEquipe = "Minha equipe";
            var participanteParaAdicionar = new Participante(10, "Daniel Oliveira");
            var participantes = new List<Participante>() { new Participante(5, "Fabrício Almeida") };
            var equipe = new Equipe(nomeEquipe, participantes);

            //Act
            equipe.AdicionarParticipante(participanteParaAdicionar);

            //Assert
            Assert.Equal(2, equipe.Participantes.Count);
        }


        [Fact]
        public void Deve_falhar_ao_adicionar_um_participante_a_uma_equipe_mais_de_uma_vez()
        {
            //Arrange
            string nomeEquipe = "Minha equipe";
            var participantes = new List<Participante>() { new Participante(10, "Daniel Oliveira") };
            var participanteParaAdicionar = new Participante(10, "Daniel Oliveira");
            var equipe = new Equipe(nomeEquipe, participantes);

            //Act - Assert
            Assert.Throws<EquipeDomainException>(() => equipe.AdicionarParticipante(participanteParaAdicionar));
        }

        [Fact]
        public void Deve_adicionar_um_participante_a_duas_equipes()
        {
            //Arrange
            var participanteParaAdicionar = new Participante(10, "Daniel Oliveira");
            string nomeEquipe1 = "Minha equipe 1";
            var participantesEquipe1 = new List<Participante>() { participanteParaAdicionar };
            string nomeEquipe2 = "Minha equipe 2";
            var participantesEquipe2 = new List<Participante>() { new Participante(5, "Fabrício Almeida") };

            var equipe1 = new Equipe(nomeEquipe1, participantesEquipe1);
            var equipe2 = new Equipe(nomeEquipe2, participantesEquipe2);

            //Act
            equipe2.AdicionarParticipante(participanteParaAdicionar);

            //Assert
            Assert.Equal(2, equipe2.Participantes.Count);
            Assert.Contains(equipe1.Participantes, p => p.Id == 10);
            Assert.Contains(equipe2.Participantes, p => p.Id == 10);
        }
    }
}
