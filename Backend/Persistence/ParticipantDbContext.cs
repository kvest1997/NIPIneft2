using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;

namespace Persistence
{
    public class ParticipantDbContext :DbContext , IParticipantDbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public ParticipantDbContext(DbContextOptions<ParticipantDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
