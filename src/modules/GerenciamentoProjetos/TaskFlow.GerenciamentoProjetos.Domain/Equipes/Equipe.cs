using System.Collections.Generic;
using System.Linq;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using TaskFlow.GerenciamentoProjetos.Domain.Participantes;

namespace TaskFlow.GerenciamentoProjetos.Domain.Equipes
{
	public class Equipe
	{
		public IReadOnlyCollection<Participante> Participantes => _participantes;
		private readonly List<Participante> _participantes = new();

		public string TituloEquipe { get; }

		public Equipe(string tituloEquipe, List<Participante> participantes)
		{
			if(participantes == null  || (participantes != null && participantes.Count == 0))
			{
				throw new EquipeDomainException("Não é possível criar uma equipe sem participantes");
			}
			TituloEquipe=tituloEquipe;
			_participantes=participantes;
		}

		public void AdicionarParticipante(Participante participante)
		{
			var participanteExistente = _participantes.FirstOrDefault(p => p.Id == participante.Id);
			if (participanteExistente != null)
			{
				throw new EquipeDomainException($"O participante {participante.Nome} já foi adicionado à equipe anteriormente.");
			}
			_participantes.Add(participante);
		}
	}
}
