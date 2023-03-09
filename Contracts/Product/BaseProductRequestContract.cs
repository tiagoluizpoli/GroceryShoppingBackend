using Contracts.BaseContracts;

namespace Contracts.Product;

public abstract class BaseProductRequestContract : BaseRequestContract
{
    public string? BarCode { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
}