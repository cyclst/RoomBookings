using RoomBookings.Common.Domain;
using RoomBookings.Common.Domain.Constants;

namespace RoomBookings.Rooms.Domain.ValueObjects;

public record Address : ValueObject
{
    public string Address1 { get; private set; }
    public string City { get; private set; }
    public string Region { get; private set; }
    public Country Country { get; private set; }
    public string PostalCode { get; private set; }

    public Address(string address1, string city, string region, Country country, string postalCode)
    {
        Address1 = address1 ?? throw new ArgumentException($"{nameof(address1)} is required");
        City = city ?? throw new ArgumentException($"{nameof(city)} is required");
        Region = region ?? throw new ArgumentException($"{nameof(region)} is required");
        Country = country;
        PostalCode = postalCode ?? throw new ArgumentException($"{nameof(postalCode)} is required");
    }
}
