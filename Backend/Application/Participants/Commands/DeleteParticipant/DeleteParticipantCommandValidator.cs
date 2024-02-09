using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Participants.Commands.DeleteParticipant
{
    public class DeleteParticipantCommandValidator
        :AbstractValidator<DeleteParticipantCommand>
    {
        public DeleteParticipantCommandValidator()
        {
            RuleFor(createParticipantCommand =>
                createParticipantCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
