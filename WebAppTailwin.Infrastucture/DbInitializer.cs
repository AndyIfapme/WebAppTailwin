using Microsoft.EntityFrameworkCore;
using WebAppTailwin.Domain.Vinyls;

namespace WebAppTailwin.Infrastucture;

public static class DbInitializer
{
    public static void Initialize(DbContext context)
    {
        context.Database.EnsureDeleted();
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
                Artist = new Artist
                {
                    FullName = "The Sonics",
                    Nationality = "US"
                }
            });

        context.SaveChanges();
    }
}