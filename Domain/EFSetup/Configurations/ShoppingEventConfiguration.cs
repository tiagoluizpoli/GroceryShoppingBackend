using Domain.EFSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFSetup.Configurations;

public class ShoppingEventConfiguration : IEntityTypeConfiguration<ShoppingEventEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingEventEntity> builder)
    {
        builder
            .HasOne(se => se.StartedBy)
            .WithMany(o => o.ShoppingEventEntities)
            .HasForeignKey(se => se.StartedById);

        builder
            .HasOne(se => se.Family)
            .WithMany(f => f.ShoppingEventEntities)
            .HasForeignKey(se => se.FamilyId);
        
        builder
            .HasOne(se => se.Market)
            .WithMany(f => f.ShoppingEventEntities)
            .HasForeignKey(se => se.MarketId);
    }
}