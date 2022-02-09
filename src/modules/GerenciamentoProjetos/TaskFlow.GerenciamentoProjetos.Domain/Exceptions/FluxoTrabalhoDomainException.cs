using Taskflow.Core.Domain;

namespace TaskFlow.GerenciamentoProjetos.Domain.Exceptions
{
	public class FluxoTrabalhoDomainException : DomainException
	{
		public FluxoTrabalhoDomainException(string message) : base(message)
		{
		}
	}
}
