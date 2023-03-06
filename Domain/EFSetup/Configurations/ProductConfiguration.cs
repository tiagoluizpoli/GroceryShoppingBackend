using Domain.EFSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EFSetup.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.BarCode).IsUnique();

            builder.HasOne(p => p.MergedProduct)
                .WithMany(mp => mp.Products);



        }
    }
}
