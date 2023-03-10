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
        public void UpdateProduct(ProductEntity product)
        {
            this.Name = product.Name;
            Description = product.Description;
            Enabled = product.Enabled;
            if (product.BarCode is not null)
            {
                BarCode = product.BarCode;
            }

            if (product.ImgUrl is not null)
            {
                ImgUrl = product.ImgUrl;
            }

            if (product.MergedProduct is not null)
            {
                MergedProduct = product.MergedProduct;
            }
        }

        public string? BarCode { get; set; }
        public string? ImgUrl { get; set; }
        public Guid? MergedProductId { get; set; }
        public MergedProductEntity? MergedProduct { get; set; }
        public List<ShoppingCartEntity> ShoppingList { get; set; }
    }
}