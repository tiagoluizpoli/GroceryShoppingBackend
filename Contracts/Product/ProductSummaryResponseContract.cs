using Contracts.BaseContracts;

namespace Contracts.Product;

public class ProductSummaryResponseContract : BaseResponseContract
{
    public string? BarCode { get; set; }
    public string? ImgUrl { get; set; }
}