using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;

namespace TaskFlow.GerenciamentoProjetos.Domain.Projeto
{
	public class Projeto
	{
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }

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
	}
}
