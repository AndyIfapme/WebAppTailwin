using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTailwin.Domain.Vinyls;
using WebAppTailwin.Infrastucture;

namespace WebAppTailwin.Host.Pages.Admins.Artists
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ArtistView Artist { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Artist.Add(new Artist
            {
                FullName = Artist.FullName,
                Description = Artist.Description,
                Nationality = Artist.Nationality
            });

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public class ArtistView
        {
            [Required(ErrorMessage = "Le nom de l'artiste est obligatoire")]
            public string FullName { get; set; } = default!;

            [MaxLength(128)]
            public string? Description { get; set; }

            public string? Nationality { get; set; }
        }
    }
}
