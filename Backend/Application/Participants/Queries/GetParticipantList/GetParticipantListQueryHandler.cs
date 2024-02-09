using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Participants.Queries.GetParticipantList
{
    public class GetParticipantListQueryHandler
        : IRequestHandler<GetParticipantListQuery, ParticipantListVm>
    {
        private readonly IParticipantDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetParticipantListQueryHandler(IParticipantDbContext dbContext,
            IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ParticipantListVm> Handle(GetParticipantListQuery requst,
            CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Participants
                .Where(note => note.Id == requst.Id)
                .ProjectTo<ParticipantLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ParticipantListVm { Participants = notesQuery };
        }
    }
}
