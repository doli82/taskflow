using System.Collections.Generic;
using Taskflow.Core.Domain;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;
using TaskFlow.GerenciamentoProjetos.Domain.FluxosTrabalho;
using TaskFlow.GerenciamentoProjetos.Domain.Participantes;

namespace TaskFlow.GerenciamentoProjetos.Domain.Projetos
{
	public class Projeto: Entity
	{
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }

		public IReadOnlyCollection<FluxoTrabalho> FluxosTrabalho => _fluxosTrabalho;
		private readonly List<FluxoTrabalho> _fluxosTrabalho = new();
		public IReadOnlyCollection<Participante> Participantes => _participantes;
		private readonly List<Participante> _participantes = new();

		public Projeto(string titulo, string descricao)
		{
			if (string.IsNullOrEmpty(titulo))
			{
				throw new ProjetoDomainException("Não é possível criar um projeto sem título.");
			}

			if (string.IsNullOrEmpty(descricao))
			{
				throw new ProjetoDomainException("Não é possível criar um projeto sem descrição.");
			}
			Titulo=titulo;
			Descricao=descricao;
		}

		public void AdicionarParticipante(int usuarioId)
		{
			_participantes.Add(new Participante(usuarioId));
		}

		public void AdicionarFluxoTrabalho(string fluxoTrabalhoNome)
		{
			_fluxosTrabalho.Add(new FluxoTrabalho(fluxoTrabalhoNome));
		}
	}
}
