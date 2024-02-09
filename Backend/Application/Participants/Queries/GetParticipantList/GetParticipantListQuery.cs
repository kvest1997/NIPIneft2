using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Participants.Queries.GetParticipantList
{
    public class GetParticipantListQuery : IRequest<ParticipantListVm>
    {
        public Guid Id { get; set; }
    }
}
