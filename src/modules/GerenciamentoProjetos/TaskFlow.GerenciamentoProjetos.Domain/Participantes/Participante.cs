using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskflow.Core.Domain;

namespace TaskFlow.GerenciamentoProjetos.Domain.Participantes
{
	public class Participante: Entity
	{
		public Participante(int usuarioId, string nome)
		{
			Id=usuarioId;
			Nome=nome;
		}

		public string Nome { get; private set; }
	}
}
