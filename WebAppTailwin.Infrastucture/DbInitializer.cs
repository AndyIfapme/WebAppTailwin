using Microsoft.EntityFrameworkCore;
using WebAppTailwin.Domain.Users;
using WebAppTailwin.Domain.Vinyls;

namespace WebAppTailwin.Infrastucture;

public static class DbInitializer
{
    public static void Initialize(DbContext context)
    {
        /*
         * La méthode EnsureDeleted() est une méthode fournie par Entity Framework Core
         * qui permet de supprimer la base de données associée au contexte de données.
         *
         * Cette méthode est utile pour nettoyer la base de données avant de la recréer
         * ou pour supprimer complètement la base de données.
         */
        context.Database.EnsureDeleted();

        /*
         * La méthode EnsureCreated() est une méthode fournie par Entity Framework Core
         * qui permet de créer la base de données associée
         * au contexte de données s'il n'existe pas déjà.
         *
         * Cette méthode est utilisée lors de la configuration initiale de l'application
         * pour s'assurer que la base de données a été créée avec le schéma requis.
         *
         */
        context.Database.EnsureCreated();

        context.Set<Vinyl>()
            .Add(new Vinyl
            {
                Title = "Here Are The Sonics",
                PublishingHouse = "Etiquette Records",
                Description = "1001 Albums You Must Hear Before You Die, David Keenan: The Best Albums Ever",
                DurationInSeconds = 1000,
                ReleaseDate = new DateTime(1965, 1,1),
                IsAlbum = true,
                Type = TypeEnum.Size33,
                Price = 25.00,
                ImageUrl = "/vinyls/vinyl-1.webp",
                Artist = new Artist
                {
                    FullName = "The Sonics",
                    Nationality = "US"
                }
            });

        context.Set<Vinyl>().Add(new Vinyl
        {
            Title = "If I Could Only Remember My Name",
            Description = "Album - 50th Anniversary",
            Price = 27.00,
            Type = TypeEnum.Size33,
            DurationInSeconds = 1200,
            ReleaseDate = new DateTime(1971, 02,22),
            IsAlbum = true,
            PublishingHouse = "Atlantic Records",
            Artist = new Artist
            {
                FullName = "David Crosby"
            }
        });

        /*
        * La méthode SaveChanges() est une méthode fournie par Entity Framework Core
        * qui permet de sauvegarder les modifications apportées aux entités associées
        * au contexte de données dans la base de données.
        *
        * Cette méthode doit être appelée pour persister les changements apportés
        * aux données dans la base de données.
        */
        context.SaveChanges();
    }
}