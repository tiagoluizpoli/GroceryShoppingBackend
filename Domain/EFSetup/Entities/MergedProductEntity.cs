using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class MergedProductEntity : AuditableEntity
{
    public string Name { get; set; }
    public List<ProductEntity> Products { get; set; }
}