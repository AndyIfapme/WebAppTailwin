using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTailwin.Domain.Vinyls;
using WebAppTailwin.Infrastucture;

namespace WebAppTailwin.Host.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        //Expose nos données à la vue Index.cshtml
        public List<VinylView> Vinyls { get; set; }

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void OnGet()
        {
            Vinyls = _applicationDbContext
                .Set<Vinyl>()
                .Select(vinyl => new VinylView
                {
                    Title = vinyl.Title,
                    Price = vinyl.Price,
                    Type = vinyl.Type,

                    ArtistFullName = vinyl.Artist.FullName
                })
                .ToList();
        }
        
        /*
         * dto (Data transfert object) permet de mettre le plus 'flat' possible les données pour le rendu HTML.
         * Le FE n'a pas besoin de savoir l'existence d'autres données que ceux qui doit utiliser
         * et évite d'avoir des structures trop complexe.
         */
        public class VinylView
        {
            public string Title { get; set; } = default!;
            public double Price { get; set; }
            public TypeEnum Type { get; set; }

            public string ArtistFullName { get; set; } = default!;
        }
    }
}