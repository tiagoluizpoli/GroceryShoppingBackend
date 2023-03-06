namespace Domain.EFSetup.Entities.Abstractions;

public abstract class DescriptiveEntity : AuditableEntity
{
    public string Name { get; set; }
    public string String { get; set; }
    public bool Enabled { get; set; }
}