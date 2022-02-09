using System;

namespace Taskflow.Core.Domain
{
	public abstract class DomainException : Exception
	{
		protected DomainException(string message) : base(message)
		{
		}
	}
}
