using Domain.EFSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFSetup.Configurations;

public class MarketConfiguration : IEntityTypeConfiguration<MarketEntity>
{
    public void Configure(EntityTypeBuilder<MarketEntity> builder)
    {
        builder
            .HasOne(m => m.Location)
            .WithOne(l => l.Market).HasForeignKey<MarketEntity>(m => m.LocationId);
    }
}