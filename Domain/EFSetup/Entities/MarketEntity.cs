using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class MarketEntity : DescriptiveEntity
{
    public MarketEntity()
    {
    }

    public MarketEntity(Guid id, DateTime createdAt, DateTime updatedAt, string name, string? description, bool enabled, Guid locationId, LocationEntity location, bool isWholeSale, List<ShoppingEventEntity> shoppingEventEntities) : base(id, createdAt, updatedAt, name, description, enabled)
    {
        LocationId = locationId;
        Location = location;
        IsWholeSale = isWholeSale;
        ShoppingEventEntities = shoppingEventEntities;
    }

    public Guid LocationId { get; set; }
    public LocationEntity Location { get; set; }
    public bool IsWholeSale { get; set; }

    public List<ShoppingEventEntity> ShoppingEventEntities { get; set; }
}