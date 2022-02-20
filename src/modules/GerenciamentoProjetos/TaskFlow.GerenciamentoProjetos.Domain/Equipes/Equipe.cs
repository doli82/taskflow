using System;
using System.Collections.Generic;
using System.Linq;
using Taskflow.Core.Domain;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using TaskFlow.GerenciamentoProjetos.Domain.Participantes;

namespace TaskFlow.GerenciamentoProjetos.Domain.Equipes
{
	public class Equipe: Entity
	{
		public IReadOnlyCollection<Participante> Participantes => _participantes;
		private readonly List<Participante> _participantes = new();

		public string TituloEquipe { get; }
		public Lider Lider { get; private set; }

		public Equipe(string tituloEquipe, List<Participante> participantes)
		{
			if (string.IsNullOrWhiteSpace(tituloEquipe))
			{
				throw new EquipeDomainException("Não é possível criar uma equipe sem fornecer o título");
			}
			if (participantes == null  || (participantes != null && participantes.Count == 0))
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

		public void PromoverParticipanteLider(int participanteId)
		{
			var participanteExistente = _participantes.FirstOrDefault(p => p.Id == participanteId);
			if (participanteExistente == null)
			{
				throw new EquipeDomainException($"O participante com ID {participanteId} não é membro da equipe.");
			}
			Lider = new Lider(participanteExistente.Id);
		}
	}
}
