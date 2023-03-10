using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class ShoppingCartEntity : AuditableEntity
{
    public Guid ShoppingEventId { get; set; }
    public ShoppingEventEntity ShoppingEvent { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public int Quantity { get; set; }
    public double FaceValue { get; set; }
    public int MinWholesaleQuantity { get; set; }
    public double WholesaleFaceValue { get; set; }
}