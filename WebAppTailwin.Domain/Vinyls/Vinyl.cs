using WebAppTailwin.Domain.Common;

namespace WebAppTailwin.Domain.Vinyls
{
    public class Vinyl : Entity
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string PublishingHouse { get; set; } = default!;
        public int DurationInSeconds { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Artist Artist { get; set; }
        public Guid ArtistId { get; set; }

        public TypeEnum Type { get; set; }

        public string? ImageUrl { get; set; }
        

        public double Price { get; set; }

        public bool IsAlbum { get; set; }
    }
}       
