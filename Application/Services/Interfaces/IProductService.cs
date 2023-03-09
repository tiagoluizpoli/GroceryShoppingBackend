using Application.Services.Interfaces.AbstractInterfaces;
using Contracts;
using Contracts.Product;
using ErrorOr;

namespace Application.Services.Interfaces;

public interface IProductService : IBaseService<ProductResponseContract, ProductSummaryResponseContract>
{
    Task<ErrorOr<ProductResponseContract>> Add(NewProductRequestContract request);
    Task<ErrorOr<ProductResponseContract>> Update(UpdateProductRequestContract request);
}