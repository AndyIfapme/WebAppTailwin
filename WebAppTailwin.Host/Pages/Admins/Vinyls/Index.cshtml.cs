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
    public class IndexModel : PageModel
    {
        private readonly WebAppTailwin.Infrastucture.ApplicationDbContext _context;

        public IndexModel(WebAppTailwin.Infrastucture.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Vinyl> Vinyl { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vinyl != null)
            {
                Vinyl = await _context.Vinyl
                .Include(v => v.Artist).ToListAsync();
            }
        }
    }
}
