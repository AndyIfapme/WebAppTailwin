using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppTailwin.Domain.Users;

namespace WebAppTailwin.Infrastucture.Configurations;

public class InvoiceAddressConfiguration : IEntityTypeConfiguration<InvoiceAddress>
{
    public void Configure(EntityTypeBuilder<InvoiceAddress> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithOne(x => x.InvoiceAddress)
            .HasForeignKey<InvoiceAddress>(x => x.UserId)
            .IsRequired(false);
    }
}