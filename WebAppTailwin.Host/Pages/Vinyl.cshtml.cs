using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTailwin.Domain.Vinyls;
using WebAppTailwin.Infrastucture;

namespace WebAppTailwin.Host.Pages
{
    public class VinylModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public VinylView? Vinyl { get; set; }

        public VinylModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(Guid id)
        {
            Vinyl = _context.Set<Vinyl>()
                .Where(x => x.Id == id)
                .Select(vinyl => new VinylView
                {
                    Title = vinyl.Title,
                    Description = vinyl.Description,
                    PublishingHouse = vinyl.PublishingHouse,
                    DurationInSeconds = vinyl.DurationInSeconds,
                    ReleaseDate = vinyl.ReleaseDate,
                    IsAlbum = vinyl.IsAlbum,
                    Price = vinyl.Price,
                    
                    ArtistId = vinyl.ArtistId,
                    ArtistFullName = vinyl.Artist.FullName
                })
                .SingleOrDefault();
        }

        public class VinylView
        {
            public string Title { get; set; } = default!;
            public string? Description { get; set; }
            public string PublishingHouse { get; set; } = default!;
            public int DurationInSeconds { get; set; }
            public DateTime ReleaseDate { get; set; }
            public TypeEnum Type { get; set; }
            public bool IsAlbum { get; set; }

            public double Price { get; set; }

            public Guid ArtistId { get; set; }
            public string ArtistFullName { get; set; } = default!;
        }
    }
}
