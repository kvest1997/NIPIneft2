using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Participants.Queries.GetParticipantList
{
    public class GetParticipantListQueryValidator
        : AbstractValidator<GetParticipantListQuery>
    {
       public GetParticipantListQueryValidator()
        {
            RuleFor(createParticipantCommand =>
                createParticipantCommand.Id).NotEqual(Guid.Empty);

        }
    }
}
