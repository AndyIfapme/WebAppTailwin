using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTailwin.Domain.Vinyls;
using WebAppTailwin.Infrastucture;

namespace WebAppTailwin.Host.Pages.Admins.Vinyls
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppTailwin.Infrastucture.ApplicationDbContext _context;

        public DetailsModel(WebAppTailwin.Infrastucture.ApplicationDbContext context)
        {
            _context = context;
        }

      public Vinyl Vinyl { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Vinyl == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyl.FirstOrDefaultAsync(m => m.Id == id);
            if (vinyl == null)
            {
                return NotFound();
            }
            else 
            {
                Vinyl = vinyl;
            }
            return Page();
        }
    }
}
