using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppTailwin.Domain.Vinyls;
using WebAppTailwin.Infrastucture;

namespace WebAppTailwin.Host.Pages.Admins.Vinyls
{
    public class EditModel : PageModel
    {
        private readonly WebAppTailwin.Infrastucture.ApplicationDbContext _context;

        public EditModel(WebAppTailwin.Infrastucture.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vinyl Vinyl { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Vinyl == null)
            {
                return NotFound();
            }

            var vinyl =  await _context.Vinyl.FirstOrDefaultAsync(m => m.Id == id);
            if (vinyl == null)
            {
                return NotFound();
            }
            Vinyl = vinyl;
           ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vinyl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinylExists(Vinyl.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VinylExists(Guid id)
        {
          return (_context.Vinyl?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
