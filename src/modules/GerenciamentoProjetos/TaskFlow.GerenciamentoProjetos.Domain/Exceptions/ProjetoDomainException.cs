using Taskflow.Core.Domain;

namespace TaskFlow.GerenciamentoProjetos.Domain.Exceptions
{
	public class ProjetoDomainException : DomainException
	{
		public ProjetoDomainException(string message) : base(message)
		{
		}
	}
}
