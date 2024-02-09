using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Participants.Commands.DeleteParticipant
{
    public class DeleteParticipantCommandHandler
        : IRequestHandler<DeleteParticipantCommand>
    {
        private readonly IParticipantDbContext _dbContext;

        public DeleteParticipantCommandHandler(IParticipantDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteParticipantCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Participants
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Participant), request.Id);
            }

            _dbContext.Participants.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
