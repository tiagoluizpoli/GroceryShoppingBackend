namespace Contracts.Product;

public class GetProductsRequestContract
{
    public string? Name { get; set; }
    public string? BarCode { get; set; }
    public bool? HasImg { get; set; }
    public bool? Enabled { get; set; }
}