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
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public Guid FamilyId { get; set; }
        public FamilyEntity FamilyEntity { get; set; }

        public List<ShoppingEventEntity> ShoppingEventEntities { get; set; }

    }
}
