using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.GerenciamentoProjetos.Domain.Equipes;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using TaskFlow.GerenciamentoProjetos.Domain.Participantes;
using Xunit;

namespace TaskFlow.GerenciamentoProjetos.UnitTests.Domain
{
	public class EquipeAggregateTest
	{
        [Fact]
        public void Deve_criar_uma_nova_equipe()
        {
            //Arrange
            var tituloEquipe = "Minha Equipe";
            var participantesEquipe = new List<Participante>() {
                new Participante(1, "Daniel Oliveira")
            };

            //Act
            var equipe = new Equipe(tituloEquipe, participantesEquipe);

            //Assert
            Assert.NotNull(equipe);
        }

        [Fact]
        public void Deve_conter_titulo_a_nova_equipe()
        {
            //Arrange
            var tituloEquipe = "Minha Equipe";
            var participantesEquipe = new List<Participante>() {
                new Participante(1, "Daniel Oliveira")
            };

            //Act
            var equipe = new Equipe(tituloEquipe, participantesEquipe);

            //Assert
            Assert.NotNull(equipe.TituloEquipe);
        }

        [Fact]
        public void Deve_conter_um_o_ou_mais_participantes_a_nova_equipe()
        {
            //Arrange
            var tituloEquipe1 = "Minha Equipe 1";
            var tituloEquipe2 = "Minha Equipe 2";
            var participantesEquipe1 = new List<Participante>() {
                new Participante(1, "Daniel Oliveira")
            };
            var participantesEquipe2 = new List<Participante>() {
                new Participante(1, "Daniel Oliveira"),
                new Participante(2, "Fabrício Almeida")
            };

            //Act
            var equipe1 = new Equipe(tituloEquipe1, participantesEquipe1);
            var equipe2 = new Equipe(tituloEquipe2, participantesEquipe2);

            //Assert
            Assert.True(equipe1.Participantes.Count == 1);
            Assert.True(equipe2.Participantes.Count > 1);
        }
        [Fact]
        public void Deve_falhar_ao_tentar_criar_uma_nova_equipe_sem_participantes()
        {
            //Arrange
            var tituloEquipe = "Minha Equipe";
            var participantesEquipe = new List<Participante>();

            //Act-Assert
            Assert.Throws<EquipeDomainException>(() => new Equipe(tituloEquipe, participantesEquipe));
        }
    }
}
