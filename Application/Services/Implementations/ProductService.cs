using Application.Repositories.Database;
using Application.Services.Interfaces;
using Application.Services.Interfaces.AbstractInterfaces;
using Contracts;
using Contracts.BaseContracts;
using Contracts.Product;
using Domain.Common.Errors.BaseErrors;
using Domain.EFSetup.Entities;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MapsterMapper;

namespace Application.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IBaseRepository<ProductEntity> _productRepository;
    private readonly IValidator<NewProductRequestContract> _newProductValidator;
    private readonly IValidator<UpdateProductRequestContract> _updateProductValidator;
    private readonly IMapper _mapper;


    public ProductService(IBaseRepository<ProductEntity> productRepository,
        IValidator<NewProductRequestContract> newProductValidator, IMapper mapper,
        IValidator<UpdateProductRequestContract> updateProductValidator)
    {
        _productRepository = productRepository;
        _newProductValidator = newProductValidator;
        _mapper = mapper;
        _updateProductValidator = updateProductValidator;
    }

    public async Task<ErrorOr<List<ProductSummaryResponseContract>>> Get<GetProductsRequestContract>(
        GetProductsRequestContract request)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<ProductResponseContract>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }


    public Task<ErrorOr<BaseNoContentResonseContract>> Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<ProductResponseContract>> Add(NewProductRequestContract request)
    {
        ValidationResult? validationResult = await _newProductValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            List<Error> errors = new();
            errors.AddRange(validationResult.Errors.Select(BaseErrors.Validation.ValidationError));
            return errors;
        }

        ProductEntity Product = _mapper.Map<ProductEntity>(request);
        ErrorOr<Created> productAddResponse = await _productRepository.Add(Product);
        if (productAddResponse.IsError)
        {
            return productAddResponse.Errors;
        }

        var ProductResponse = _mapper.Map<ProductResponseContract>(Product);
        return ProductResponse;
    }

    public async Task<ErrorOr<ProductResponseContract>> Update(UpdateProductRequestContract request)
    {
        ValidationResult? validationResult = await _updateProductValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            List<Error> errors = new();
            errors.AddRange(validationResult.Errors.Select(BaseErrors.Validation.ValidationError));
            return errors;
        }

        ProductEntity Product = _mapper.Map<ProductEntity>(request);

        ErrorOr<ProductEntity?> LoadedProductResponse = await _productRepository.GetById(Product.Id);
        if (LoadedProductResponse.IsError)
        {
            return LoadedProductResponse.Errors;
        }

        ProductEntity? LoadedProduct = LoadedProductResponse.Value;
        LoadedProduct.UpdateProduct(Product);

        ErrorOr<Updated> UpdatedProductResponse = await _productRepository.Update(LoadedProduct);
        if (UpdatedProductResponse.IsError)
        {
            return UpdatedProductResponse.Errors;
        }

        ProductResponseContract ProductResponse = _mapper.Map<ProductResponseContract>(LoadedProduct);
        return ProductResponse;
    }
}