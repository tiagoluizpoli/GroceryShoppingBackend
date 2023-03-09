using Application.Services.Interfaces;
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
}