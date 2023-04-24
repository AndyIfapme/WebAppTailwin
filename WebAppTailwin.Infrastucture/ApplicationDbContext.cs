using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppTailwin.Infrastucture
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Appel automatiquement les configurations héritant de IEntityTypeConfiguration dans l'assembly défini.
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //builder.ApplyConfiguration(new VinylConfiguration());
            //builder.ApplyConfiguration(new ArtistConfiguration());

            base.OnModelCreating(builder);
        }
    }
}