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
        public Guid OwnerId { get; set; }
        public UserEntity Owner { get; set; }
        public List<UserEntity> Members { get; set; }

        public List<ShoppingEventEntity> ShoppingEventEntities { get; set; }

    }
}
