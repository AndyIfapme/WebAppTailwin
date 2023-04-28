using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppTailwin.Domain.Vinyls;

namespace WebAppTailwin.Infrastucture.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        /*
         * La méthode HasKey() est une méthode de l'API Fluent d'Entity Framework Core
         * qui permet de spécifier la clé primaire d'une entité.
         *
         * La clé primaire est un champ ou une combinaison de champs qui identifie
         * de manière unique chaque enregistrement dans une table de la base de données.
         */
        builder.HasKey(x => x.Id);

        /*
         * La méthode HasMany() est une méthode de l'API Fluent d'Entity Framework Core
         * qui permet de spécifier la relation "un à plusieurs" entre deux entités.
         *
         * Dans l'exemple de code fourni, builder.HasMany(x => x.Vinyls) indique que
         * l'entité représentée par la classe Artist a une relation "un à plusieurs"
         * avec l'entité représentée par la classe Vinyl.
         *
         * La méthode WithOne() spécifie l'entité liée à la relation, qui est l'entité Artist dans ce cas.
         * La méthode HasForeignKey() est utilisée pour spécifier la clé étrangère de la relation,
         * qui est la propriété ArtistId de l'entité Vinyl.
         *
         * Enfin, la méthode IsRequired() spécifie que la clé étrangère ArtistId est requise, ce qui signifie qu'une entité Vinyl ne peut pas exister sans être liée à une entité Artist.
         */
        builder.HasMany(x => x.Vinyls)
            .WithOne(x => x.Artist)
            .HasForeignKey(x => x.ArtistId)
            .IsRequired();
    }
}