namespace Domain.EFSetup.Entities.Abstractions;

public abstract class DescriptiveEntity : AuditableEntity
{
    public DescriptiveEntity()
    {
    }


    public DescriptiveEntity(string name, string? description,
        bool enabled)
    {
        Name = name;
        Description = description;
        Enabled = enabled;
    }

    public string Name { get; set; }
    public string? Description { get; set; }
    public bool Enabled { get; set; } = true;
}