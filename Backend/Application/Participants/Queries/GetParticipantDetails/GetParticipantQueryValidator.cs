using Application.Participants.Quires.GetParticipantDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Participants.Queries.GetParticipantDetails
{
    public class GetParticipantQueryValidator
        :AbstractValidator<GetParticipantDetailsQuery>
    {
        public GetParticipantQueryValidator()
        {
            RuleFor(createParticipantCommand =>
                createParticipantCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
