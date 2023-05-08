﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly WebAppTailwin.Infrastucture.ApplicationDbContext _context;

        public IndexModel(WebAppTailwin.Infrastucture.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Artist != null)
            {
                Artist = await _context.Artist.ToListAsync();
            }
        }
    }
}
