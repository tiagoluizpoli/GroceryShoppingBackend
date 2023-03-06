using Domain.EFSetup.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EFSetup.Entities
{
    public class ShoppingEventEntity : AuditableEntity
    {
        public DateTime StartDateTime { get; set; }
        public Guid StartedById { get; set; }
        public UserEntity StartedBy { get; set; }
        public Guid FamilyId { get; set; }
        public FamilyEntity Family { get; set; }
        public Guid MarketId { get; set; }
        public MarketEntity Market { get; set; }

        public List<ShoppingListEntity> ShoppingListEntities { get; set; }
    }
}