using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Participants.Commands.UpdateParticipant
{
    public class UpdateParticipantCommandHandler
        : IRequestHandler<UpdateParticipantCommand>
    {
        private readonly IParticipantDbContext _dbContext;
        public UpdateParticipantCommandHandler(IParticipantDbContext dbContext)
            => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateParticipantCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Participants.FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Participant), request.Id);
            }

            entity.Sity = request.Sity;
            entity.NameParticipant = request.NameParticipant;
            entity.Experience = request.Experience;
            entity.Age = request.Age;
            entity.GenderId = request.GenderId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
