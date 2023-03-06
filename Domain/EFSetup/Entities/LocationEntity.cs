using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class LocationEntity : AuditableEntity
{
    public LocationEntity()
    {
    }

    public LocationEntity(Guid id, DateTime createdAt, DateTime updatedAt, string latitude, string longitude, MarketEntity market) : base(id, createdAt, updatedAt)
    {
        Latitude = latitude;
        Longitude = longitude;
        Market = market;
    }

    public string Latitude { get; set; }
    public string Longitude { get; set; }

    public MarketEntity Market { get; set; }
}