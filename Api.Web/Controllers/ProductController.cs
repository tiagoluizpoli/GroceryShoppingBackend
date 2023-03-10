using Application.Services.Interfaces;
using Contracts.BaseContracts;
using Contracts.Product;
using Domain.GlobalConstants;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[ApiController]
[Route($"{ApiVersions.ApiV1}[Controller]")]
public class ProductController : ApiController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get([FromQuery] GetProductsRequestContract request)
    {
        ErrorOr<List<ProductSummaryResponseContract>> response = await _productService.Get(request);
        return response.Match(Ok, Problem);
    }

    [HttpGet("GetById/{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        ErrorOr<ProductResponseContract> response = await _productService.GetById(id);
        return response.Match(Ok, Problem);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddProduct(NewProductRequestContract request)
    {
        ErrorOr<ProductResponseContract> response = await _productService.Add(request);
        return response
            .Match(success => Created("", success),
                Problem);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequestContract request)
    {
        ErrorOr<ProductResponseContract> response = await _productService.Update(request);
        return response.Match(Ok, Problem);
    }

    [HttpDelete("Delete/{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        ErrorOr<BaseNoContentResonseContract> response = await _productService.Delete(id);
        return response.Match(Ok, Problem);
    }
}