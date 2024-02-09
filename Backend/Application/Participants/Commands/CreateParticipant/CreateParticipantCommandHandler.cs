using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Participants.Commands.CreateParticipant
{
    public class CreateParticipantCommandHandler
        :IRequestHandler<CreateParticipantCommand, Guid>
    {
        private readonly IParticipantDbContext _dbContext;
        public CreateParticipantCommandHandler(IParticipantDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateParticipantCommand request,
            CancellationToken cancellationToken)
        {
            var participant = new Participant
            {
                Id = Guid.NewGuid(),
                NameParticipant = request.NameParticipant,
                GenderId = request.GenderId,
                Age = request.Age,
                Experience = request.Experience,
                Sity = request.Sity
            };

            await _dbContext.Participants.AddAsync(participant, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return participant.Id;
        }
    }
}
