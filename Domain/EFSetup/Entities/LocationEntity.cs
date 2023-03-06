using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class LocationEntity : AuditableEntity
{
    public string Latitude { get; set; }
    public string Longitude { get; set; }

    public MarketEntity Market { get; set; }
}