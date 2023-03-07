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
        public ProductEntity()
        {
        }

        public ProductEntity(Guid id, DateTime createdAt, DateTime updatedAt, string name, string? description,
            bool enabled, string barCode, string imgUrl, MergedProductEntity mergedProduct,
            List<ShoppingCartEntity> shoppingList) : base(id, createdAt, updatedAt, name, description, enabled)
        {
            BarCode = barCode;
            ImgUrl = imgUrl;
            MergedProduct = mergedProduct;
            ShoppingList = shoppingList;
        }

        public string BarCode { get; set; }
        public string ImgUrl { get; set; }
        public MergedProductEntity MergedProduct { get; set; }
        public List<ShoppingCartEntity> ShoppingList { get; set; }
    }
}