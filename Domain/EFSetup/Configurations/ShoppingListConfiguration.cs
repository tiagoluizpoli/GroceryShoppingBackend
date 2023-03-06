using Domain.EFSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFSetup.Configurations;

public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingListEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingListEntity> builder)
    {
        builder.HasKey(sl => sl.Id);

        builder
            .HasOne(sl => sl.Product)
            .WithMany(p => p.ShoppingList)
            .HasForeignKey(sl => sl.ProductId);

        builder
            .HasOne(sl => sl.ShoppingEvent)
            .WithMany(se => se.ShoppingListEntities)
            .HasForeignKey(sl => sl.ShoppingEventId);
    }
}