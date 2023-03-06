using Domain.EFSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFSetup.Configurations;

public class FamilyConfiguration : IEntityTypeConfiguration<FamilyEntity>
{
    public void Configure(EntityTypeBuilder<FamilyEntity> builder)
    {
        builder
            .HasOne(f => f.Owner);
           

        builder
            .HasMany(f => f.Members)
            .WithOne(u => u.FamilyEntity)
            .HasForeignKey(f => f.FamilyId);
    }
}