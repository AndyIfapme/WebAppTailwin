using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTailwin.Domain.Vinyls;
using WebAppTailwin.Infrastucture;

namespace WebAppTailwin.Host.Pages.Admins.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppTailwin.Infrastucture.ApplicationDbContext _context;

        public DetailsModel(WebAppTailwin.Infrastucture.ApplicationDbContext context)
        {
            _context = context;
        }

      public Artist Artist { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }
            else 
            {
                Artist = artist;
            }
            return Page();
        }
    }
}
