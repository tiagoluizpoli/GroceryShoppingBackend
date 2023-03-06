using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class MergedProductEntity : AuditableEntity
{
    public MergedProductEntity()
    {
    }

    public MergedProductEntity(Guid id, DateTime createdAt, DateTime updatedAt, string name,
        List<ProductEntity> products) : base(id, createdAt, updatedAt)
    {
        Name = name;
        Products = products;
    }

    public string Name { get; set; }
    public List<ProductEntity> Products { get; set; }
}