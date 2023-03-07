using Domain.EFSetup.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EFSetup.Entities
{
    public class UserEntity : AuditableEntity
    {
        public UserEntity()
        {
        }


        public UserEntity(Guid id, DateTime createdAt, DateTime updatedAt, string name, string lastName,
            string socialSecurityNumber, string email, bool enabled, Guid familyId, FamilyEntity familyEntity,
            List<ShoppingEventEntity> shoppingEventEntities) : base(id, createdAt, updatedAt)
        {
            Name = name;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            Email = email;
            Enabled = enabled;
            FamilyId = familyId;
            FamilyEntity = familyEntity;
            ShoppingEventEntities = shoppingEventEntities;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; } = true;
        public Guid? FamilyId { get; set; }
        public FamilyEntity? FamilyEntity { get; set; }

        public FamilyEntity FamilyOwned { get; set; }
        public List<ShoppingEventEntity> ShoppingEventEntities { get; set; }
    }
}