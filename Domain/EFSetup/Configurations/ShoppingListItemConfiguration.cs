using Domain.EFSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFSetup.Configurations;

public class ShoppingListItemConfiguration : IEntityTypeConfiguration<ShoppingListItems>
{
    public void Configure(EntityTypeBuilder<ShoppingListItems> builder)
    {
        builder.HasKey(sli => sli.Id);

        builder
            .HasOne(sli => sli.List)
            .WithMany(l => l.Items)
            .HasForeignKey(sli => sli.ListId);
    }
}