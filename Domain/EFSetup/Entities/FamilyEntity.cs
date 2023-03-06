using Domain.EFSetup.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EFSetup.Entities
{
    public class FamilyEntity : DescriptiveEntity
    {
        public FamilyEntity()
        {
        }
        
        


        public FamilyEntity(Guid id, DateTime createdAt, DateTime updatedAt, string name, string? description,
            bool enabled, Guid ownerId, UserEntity owner, List<UserEntity> members,
            List<ShoppingEventEntity>? shoppingEventEntities) : base(id, createdAt, updatedAt, name, description,
            enabled)
        {
            OwnerId = ownerId;
            Owner = owner;
            Members = members;
            ShoppingEventEntities = shoppingEventEntities;
        }

        public Guid OwnerId { get; set; }
        public UserEntity Owner { get; set; }
        public List<UserEntity> Members { get; set; }

        public List<ShoppingEventEntity>? ShoppingEventEntities { get; set; } = null!;
    }
}