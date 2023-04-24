using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppTailwin.Domain.Vinyls;

namespace WebAppTailwin.Infrastucture.Configurations
{
    public class VinylConfiguration : IEntityTypeConfiguration<Vinyl>
    {
        // https://learn.microsoft.com/fr-fr/ef/core/modeling/entity-types?tabs=data-annotations

        public void Configure(EntityTypeBuilder<Vinyl> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
