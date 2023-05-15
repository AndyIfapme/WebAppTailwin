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
            /*
             * La méthode HasKey() est une méthode de l'API Fluent d'Entity Framework Core
             * qui permet de spécifier la clé primaire d'une entité.
             *
             * La clé primaire est un champ ou une combinaison de champs qui identifie
             * de manière unique chaque enregistrement dans une table de la base de données.
             */
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Artist)
            //    .WithMany(x => x.Vinyls)
            //    .HasForeignKey(x => x.ArtistId)
            //    .IsRequired();
        }
    }
}
