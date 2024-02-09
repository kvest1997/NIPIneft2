using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IParticipantDbContext
    {
        DbSet<Participant> Participants { get; set; }
        DbSet<Gender> Genders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}
