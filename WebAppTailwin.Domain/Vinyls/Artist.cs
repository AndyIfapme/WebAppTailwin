namespace WebAppTailwin.Domain.Vinyls;

public class Artist
{
    public string FullName { get; set; } = default!;
    public string? Description { get; set; }

    public string? Nationality { get; set; }

    public ICollection<Vinyl> Vinyls { get; set; }
}