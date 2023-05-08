using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppTailwin.Domain.Vinyls;

namespace WebAppTailwin.Infrastucture
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Vinyl> Vinyl { get; set; }
        public DbSet<Artist> Artist { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=aspnet-WebAppTailwin.Host-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        /*
         *La méthode OnModelCreating est une méthode fournie par Entity Framework Core qui est appelée
         * lors de la création du modèle de données par le contexte DbContext.
         *
         * Cette méthode est utilisée pour configurer les entités, les relations,
         * les index, les clés étrangères, etc. avant qu'Entity Framework Core ne crée
         * le schéma de base de données.
         */
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*
             * La méthode `ApplyConfigurationsFromAssembly` est une méthode fournie
             * par Entity Framework Core qui permet de charger et d'appliquer automatiquement
             * les configurations d'entités et de relations à partir d'un assembly donné.
             *
             * Elle prend en paramètre un objet Assembly qui représente l'assembly contenant
             * les configurations à appliquer.
             */
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


            /*
             * Le code ci-dessous est une alternative à 'ApplyConfigurationsFromAssembly'
             * mais nécessite une intervention manuel à chaque nouvelle configuration
             */
            //builder.ApplyConfiguration(new VinylConfiguration());
            //builder.ApplyConfiguration(new ArtistConfiguration());

            base.OnModelCreating(builder);
        }
    }
}