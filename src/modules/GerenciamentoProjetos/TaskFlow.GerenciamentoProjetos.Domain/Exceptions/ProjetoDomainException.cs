using System;

namespace TaskFlow.GerenciamentoProjetos.Domain.Exceptions
{
	public class ProjetoDomainException : Exception
	{
		public ProjetoDomainException(string message) : base(message)
		{
		}
	}
}
