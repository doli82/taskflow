﻿using System.Collections.Generic;
using Taskflow.Core.Domain;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;

namespace TaskFlow.GerenciamentoProjetos.Domain.Projeto
{
	public class Projeto: Entity
	{
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }

		public IReadOnlyCollection<FluxoTrabalho> FluxosTrabalho => _fluxosTrabalho;
		private readonly List<FluxoTrabalho> _fluxosTrabalho = new();

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

		public void AdicionarFluxoTrabalho(string fluxoTrabalhoNome)
		{
			_fluxosTrabalho.Add(new FluxoTrabalho(fluxoTrabalhoNome));
		}
	}
}
