namespace WebApplication1;

public record OrderForm(
    string Name,
    string Line1,
    string Line2,
    string Line3,
    string City,
    string State,
    string Zip,
    string Country,
    bool GiftWrap);