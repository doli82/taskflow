using Taskflow.Core.Domain;
using TaskFlow.GerenciamentoProjetos.Domain.Exceptions;

namespace TaskFlow.GerenciamentoProjetos.Domain.Equipes
{
	public class Lider : Entity
	{
		public Lider(int participanteId)
		{
			if(participanteId == 0) 
			{
				throw new EquipeDomainException("O lider precisa ser um participante existente.");
			}

			ParticipanteId=participanteId;
		}

		public int ParticipanteId { get; private set; }
		public int EquipeId { get; private set; }
	}
}
