using MediatR;
using System;

namespace Application.Participants.Commands.DeleteParticipant
{
    public class DeleteParticipantCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
