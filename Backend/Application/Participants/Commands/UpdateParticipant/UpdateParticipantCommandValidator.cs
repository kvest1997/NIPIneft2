using Application.Participants.Commands.CreateParticipant;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Participants.Commands.UpdateParticipant
{
    public class UpdateParticipantCommandValidator 
        : AbstractValidator<UpdateParticipantCommand>
    {
        public UpdateParticipantCommandValidator()
        {
            RuleFor(createParticipantCommand =>
                createParticipantCommand.NameParticipant).NotEmpty().MaximumLength(128);
            RuleFor(createParticipantCommand =>
                createParticipantCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createParticipantCommand =>
                createParticipantCommand.Age).NotEmpty();
            RuleFor(createParticipantCommand =>
                createParticipantCommand.Sity).NotEmpty().MaximumLength(128);
            RuleFor(createParticipantCommand =>
                createParticipantCommand.Experience).NotEmpty();
            RuleFor(createParticipantCommand =>
                createParticipantCommand.GenderId).NotEqual(Guid.Empty);
        }
    }
}
