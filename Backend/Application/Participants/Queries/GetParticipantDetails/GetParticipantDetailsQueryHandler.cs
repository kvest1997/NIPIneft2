using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Participants.Quires.GetParticipantDetails
{
    public class GetParticipantDetailsQueryHandler
        : IRequestHandler<GetParticipantDetailsQuery, ParticipantDetailsVm>
    {
        private readonly IParticipantDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetParticipantDetailsQueryHandler(IParticipantDbContext dbContext,
            IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ParticipantDetailsVm> Handle(GetParticipantDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Participants
                .FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Participant), request.Id);
            }

            return _mapper.Map<ParticipantDetailsVm>(entity);
        }
    }
}
