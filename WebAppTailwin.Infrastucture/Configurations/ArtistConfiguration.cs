using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppTailwin.Domain.Vinyls;

namespace WebAppTailwin.Infrastucture.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Vinyls)
            .WithOne(x => x.Artist)
            .HasForeignKey(x => x.ArtistId)
            .IsRequired();
    }
}