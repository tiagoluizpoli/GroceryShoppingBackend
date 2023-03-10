using System.Linq.Expressions;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    public async Task<ErrorOr<List<ProductSummaryResponseContract>>> Get(GetProductsRequestContract request)
    {
        Expression<Func<ProductEntity, bool>>? filter = p => p != null;

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            filter = (p => p.Name.ToLower().Contains(request.Name.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(request.BarCode))
        {
            filter = (p => p.BarCode.Contains(request.BarCode));
        }

        if (request.Enabled != null)
        {
            filter = (p => p.Enabled == request.Enabled);
        }

        if (request.HasImg != null)
        {
            filter = (p =>
                (bool)request.HasImg ? !string.IsNullOrWhiteSpace(p.ImgUrl) : string.IsNullOrWhiteSpace(p.ImgUrl));
        }

        ErrorOr<List<ProductEntity>> ProductListResponse = await _productRepository.GetAll(filter);
        if (ProductListResponse.IsError)
        {
            return ProductListResponse.Errors;
        }

        List<ProductSummaryResponseContract> ProductList =
            _mapper.Map<List<ProductSummaryResponseContract>>(ProductListResponse.Value);

        return ProductList;
    }

    public async Task<ErrorOr<ProductResponseContract>> GetById(Guid id)
    {
        if (id == null)
        {
            return BaseErrors.DefaultErrors.NullParameter;
        }

        ErrorOr<ProductEntity?> ProductResponse = await _productRepository.GetById(id);
        if (ProductResponse.IsError)
        {
            return ProductResponse.Errors;
        }

        ProductResponseContract Product = _mapper.Map<ProductResponseContract>(ProductResponse.Value);

        return Product;
    }

    public async Task<ErrorOr<BaseNoContentResonseContract>> Delete(Guid Id)
    {
        if (Id == null)
        {
            return BaseErrors.DefaultErrors.NullParameter;
        }

        ErrorOr<ProductEntity?> product = await _productRepository.GetById(Id);
        if (product.IsError)
        {
            return product.Errors;
        }

        ErrorOr<Deleted> deleteResponse = await _productRepository.Delete(product.Value);
        if (deleteResponse.IsError)
        {
            return deleteResponse.Errors;
        }

        BaseNoContentResonseContract response = new BaseNoContentResonseContract("Product Deleted Successfully");

        return response;
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