using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.FluxosTrabalho.Domain.Exceptions
{
	public class FluxoTrabalhoDomainException : Exception
	{
		public FluxoTrabalhoDomainException(string message) : base(message)
		{
		}
	}
}
