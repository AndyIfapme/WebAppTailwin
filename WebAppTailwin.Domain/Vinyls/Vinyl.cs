namespace WebAppTailwin.Domain.Vinyls
{
    public class Vinyl
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string PublishingHouse { get; set; } = default!;
        public int DurationInSeconds { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Artist Artist { get; set; }

        public TypeEnum Type { get; set; }
        

        public double Price { get; set; }

        public bool IsAlbum { get; set; }
    }
}       
