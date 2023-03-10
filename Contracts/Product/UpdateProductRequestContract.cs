namespace Contracts.Product;

public class UpdateProductRequestContract : BaseProductRequestContract
{
    public Guid Id { get; set; }
}