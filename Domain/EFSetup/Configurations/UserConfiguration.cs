using Domain.EFSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFSetup.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasOne(u => u.Family)
            .WithMany(fe => fe.Members)
            .HasForeignKey(u => u.FamilyId)
            .IsRequired(false);

        builder
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}