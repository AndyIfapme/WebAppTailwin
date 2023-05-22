using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppTailwin.Domain.Users;
using WebAppTailwin.Infrastucture;

namespace WebAppTailwin.Host.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public InvoiceAddressView InvoiceAddress { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var invoiceAddress =  await _context
                .InvoiceAddresses
                .AsNoTracking()
                .Where(x => x.UserId == user.Id)
                .Select(x => new InvoiceAddressView
                {
                    Street = x.Street,
                    City = x.City,
                    Country = x.Country,
                    StreetNumber = x.StreetNumber,
                    ZipCode = x.ZipCode
                })
                .SingleOrDefaultAsync();
            
            InvoiceAddress = invoiceAddress;
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
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

            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var invoiceAddress = await _context
                .InvoiceAddresses
                .SingleOrDefaultAsync(x => x.UserId == user.Id );

            if (invoiceAddress is null)
            {
                await _context.InvoiceAddresses.AddAsync(
                    new InvoiceAddress
                    {
                        City = InvoiceAddress.City,
                        Country = InvoiceAddress.Country,
                        Street = InvoiceAddress.Street,
                        StreetNumber = InvoiceAddress.StreetNumber,
                        ZipCode = InvoiceAddress.ZipCode,
                        UserId = user.Id
                    }
                );
            }
            else
            {
                invoiceAddress.City = InvoiceAddress.City;
                invoiceAddress.Country = InvoiceAddress.Country;
                invoiceAddress.Street = InvoiceAddress.Street;
                invoiceAddress.StreetNumber = InvoiceAddress.StreetNumber;
                invoiceAddress.ZipCode = InvoiceAddress.ZipCode;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool InvoiceAddressExists(Guid id)
        {
          return (_context.InvoiceAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public class InvoiceAddressView
        {
            [Required]
            public string Street { get; set; }

            [Required]
            public string StreetNumber { get; set; }

            [Required]
            public string ZipCode { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public string Country { get; set; }
        }
    }
}
