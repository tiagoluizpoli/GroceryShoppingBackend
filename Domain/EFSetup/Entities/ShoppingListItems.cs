using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class ShoppingListItems : AuditableEntity
{
    public Guid ListId { get; set; }
    public ShoppingListEntity List { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public bool Grabbed { get; set; }
}