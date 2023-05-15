using WebAppTailwin.Domain.Common;

namespace WebAppTailwin.Domain.Users;

public class InvoiceAddress : Entity
{
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }

    public string Country { get; set; }


    public User User { get; set; }
    public string UserId { get; set; }
}