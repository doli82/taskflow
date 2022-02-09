using Taskflow.Core.Domain;

// Implementação inicial com base nas especificações deste link:
// https://www.atlassian.com/br/agile/project-management/workflow

namespace TaskFlow.GerenciamentoProjetos.Domain.FluxosTrabalho
{
	public class Estado: Entity
	{
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }
		public Estado(string titulo, string descricao)
		{
			Titulo=titulo;
			Descricao=descricao;
		}
	}


	//		PARA FAZER
	//Trabalho que não foi iniciado

	//EM ANDAMENTO
	//Trabalho que está sendo feito pela equipe

	//REVISÃO DE CÓDIGO
	//Trabalho que está concluído, mas está esperando revisão

	//CONCLUÍDO
	//Trabalho que está finalizado e atende a definição da equipe de concluído
}
