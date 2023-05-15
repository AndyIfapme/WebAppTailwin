using Microsoft.AspNetCore.Identity;

namespace WebAppTailwin.Domain.Users;

public class User : IdentityUser
{
    public InvoiceAddress? InvoiceAddress { get; set; }
}