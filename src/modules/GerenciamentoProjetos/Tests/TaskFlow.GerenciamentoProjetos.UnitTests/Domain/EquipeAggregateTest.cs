using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.GerenciamentoProjetos.Domain.Equipes;
using Xunit;

namespace TaskFlow.GerenciamentoProjetos.UnitTests.Domain
{
	public class EquipeAggregateTest
	{
        [Fact]
        public void Deve_criar_uma_nova_equipe()
        {
            //Arrange


            //Act
            var equipe = new Equipe();

            //Assert
            Assert.NotNull(equipe);
        }
    }
}
