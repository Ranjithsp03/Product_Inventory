using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace ProductsInventory.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using ProductsInventory.Api.Data.DTOs;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Models.Requests;
using ProductsInventory.Api.Models.Responses;
using ProductsInventory.Api.Services;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private IproductService _productservice;
    public ProductsController(IproductService productservice)
    {
        _productservice = productservice;
    }
    // [HttpPost]
    // public ActionResult CreateProduct([FromBody] Product product)
    // {

    //     Product newproduct = _producservice.AddProduct(product);
    //     return Ok(newproduct);
    // }

    // [HttpGet("{id}")]
    // public ActionResult GetProduct(string id)
    // {
    //     Product product = _producservice.GetProduct(id);
    //     return Ok(product);
    // }

    // [HttpGet()]
    // public ActionResult GetAllProduct()
    // {
    //     var product = _producservice.GetAllProducts();
    //     return Ok(product);
    // }
    [Authorize]
    
     [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var result = await _productservice.CreateProduct(request);
        if (result == null)
        {
            return BadRequest(new ApiResponse<ProductDto>(false, "Product Creation Failed", null));
        }
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, new ApiResponse<ProductDto>(true, "Product Created Successfully", result));
    }

    // Get List of Products
      [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productservice.GetAll();
        return Ok(new ApiResponse<IEnumerable<ProductDto>>(true, "Products Fetched Successfully", result));
    }

    // Get a Product by Id
      [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _productservice.GetById(id);
        if (result == null)
        {
            return NotFound(new ApiResponse<ProductDto>(false, "Product Not Found", null));
        }
        return Ok(new ApiResponse<ProductDto>(true, "Product Fetched Successfully", result));
    }

    // [HttpPut("{id}")]
    // public ActionResult UpdateProduct(string id,[FromBody] Product product)
    // {

    //     Product product1 = _productservice.UpdateProduct(id,product);
    //     return Ok(product1);
    // }
  [Authorize]
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
    {
        var result = await _productservice.UpdateProduct(id, request);
        if (result == null)
        {
            return NotFound(new ApiResponse<ProductDto>(false, "Product Not Found", null));
        }
        return Ok(new ApiResponse<ProductDto>(true, "Product Updated Successfully", result));
    }
  [Authorize]
     [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var result = await _productservice.DeleteProductAsync(id);
        if (!result)
        {
            return NotFound(new ApiResponse<bool>(false, "Product Not Found", false));
        }
        return Ok(new ApiResponse<bool>(true, "Product Deleted Successfully", true));
    }
}