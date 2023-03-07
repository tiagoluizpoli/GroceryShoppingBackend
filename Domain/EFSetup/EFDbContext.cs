using Domain.EFSetup.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.EFSetup.Entities.Abstractions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Domain.EFSetup
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Domain"));
        }

        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<FamilyEntity> Family { get; set; }
        public DbSet<LocationEntity> Location { get; set; }
        public DbSet<MarketEntity> Market { get; set; }
        public DbSet<ShoppingEventEntity> ShoppingEvent { get; set; }
        public DbSet<ShoppingCartEntity> ShoppingCart { get; set; }
        public DbSet<ShoppingListEntity> ShoppingList { get; set; }
        public DbSet<ShoppingListItems> ShoppingListItems { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<MergedProductEntity> MergedProduct { get; set; }
        
        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                ((AuditableEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
