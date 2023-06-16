using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppTailwin.Domain.Vinyls;
using WebAppTailwin.Infrastucture;

namespace WebAppTailwin.Host.Pages.Admins.Vinyls
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public VinylView Vinyl { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //On génére un nom unique pour éviter "d'écraser" un fichier sans le vouloir dans le temps.
            var fileName = Guid.NewGuid() + Path.GetExtension(Vinyl.File.FileName);
            var imageUrl = Path.Combine(_webHostEnvironment.WebRootPath, "vinyls", fileName);
            var urls = imageUrl.Split("wwwroot");

            await using var stream = new FileStream(imageUrl, FileMode.Create);
            await Vinyl.File.CopyToAsync(stream);

            _context.Vinyl.Add(new Vinyl
            {
                Title = Vinyl.Title,
                Description = Vinyl.Description,
                ReleaseDate = Vinyl.ReleaseDate,
                Type = Vinyl.Type ?? TypeEnum.Size33,
                DurationInSeconds = Vinyl.DurationInSeconds,
                IsAlbum = Vinyl.IsAlbum,
                Price = Vinyl.Price,
                PublishingHouse = Vinyl.PublishingHouse,
                ArtistId = Vinyl.ArtistId,
                ImageUrl = urls[1]
            });
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public class VinylView
        {
            public string Title { get; set; } = default!;
            public string? Description { get; set; }
            public string PublishingHouse { get; set; } = default!;
            public int DurationInSeconds { get; set; }
            public DateTime ReleaseDate { get; set; }
            public Guid ArtistId { get; set; }

            public TypeEnum? Type { get; set; }
            public IFormFile File { get; set; } = default!;


            public double Price { get; set; }

            public bool IsAlbum { get; set; }
        }
    }
}
