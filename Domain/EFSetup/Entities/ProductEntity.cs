using Domain.EFSetup.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EFSetup.Entities
{
    public class ProductEntity : DescriptiveEntity
    {
        public string BarCode { get; set; }
        public string ImgUrl { get; set; }
        public MergedProductEntity MergedProduct { get; set; }
        public List<ShoppingListEntity> ShoppingList { get; set; }
    }
}
