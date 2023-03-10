using Contracts.BaseContracts;

namespace Contracts.Product;

public class ProductResponseContract : BaseResponseContract
{
    public string Description { get; set; }
    public bool Enabled { get; set; }
    public string BarCode { get; set; }
    public string? ImgUrl { get; set; }
    
}