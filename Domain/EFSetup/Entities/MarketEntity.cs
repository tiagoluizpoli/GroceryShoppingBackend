using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class MarketEntity : DescriptiveEntity
{
    public Guid LocationId { get; set; }
    public LocationEntity Location { get; set; }
    public bool IsWholeSale { get; set; }

    public List<ShoppingEventEntity> ShoppingEventEntities { get; set; }
}