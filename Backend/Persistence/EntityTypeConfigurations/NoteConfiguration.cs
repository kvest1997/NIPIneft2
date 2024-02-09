using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Sity).HasMaxLength(128);
            builder.Property(note => note.NameParticipant).HasMaxLength(128);
            builder.Property(note => note.Age);
            builder.HasKey(note => note.GenderId);
        }
    }
}
