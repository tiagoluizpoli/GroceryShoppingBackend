using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class ShoppingListEntity : DescriptiveEntity
{
    public List<ShoppingListItems> Items { get; set; }
}