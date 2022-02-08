using System;
using System.Collections.Generic;
using System.Linq;
using Taskflow.Core.Domain;
using TaskFlow.FluxosTrabalho.Domain.Exceptions;

// Implementação inicial com base nas especificações deste link:
// https://www.atlassian.com/br/agile/project-management/workflow

namespace TaskFlow.FluxosTrabalho.Domain
{
	public class FluxoTrabalho: Entity
	{
		public string Titulo { get; private set; }

		public IEnumerable<Estado> Estados => _estados;
		private readonly List<Estado> _estados = new List<Estado>();

		public FluxoTrabalho(string titulo)
		{
			if (string.IsNullOrWhiteSpace(titulo))
			{
				throw new FluxoTrabalhoDomainException("Não é possível criar um fluxo de trabalho sem fornecer o título.");
			}

			Titulo = titulo;
		}

		public void AdicionarEstado(string titulo, string descricao = "")
		{
			if (string.IsNullOrWhiteSpace(titulo))
				throw new FluxoTrabalhoDomainException($"O estado do fluxo de trabalho precisa conter um título.");

			if (_estados.Any(e => e.Titulo == titulo))
				throw new FluxoTrabalhoDomainException($"Já existe um estado com o título {titulo}.");

			_estados.Add(new Estado(titulo, descricao));
		}
	}
}
