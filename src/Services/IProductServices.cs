using ProductsInventory.Api.Data.DTOs;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Models.Requests;

namespace ProductsInventory.Api.Services;

public interface IproductService
{
    // public Product GetProduct(string id);
    // public Product AddProduct(Product product);
    // List<Product> GetAllProducts();
    // public void DeleteProduct(string id);
    // public Product UpdateProduct(string id,Product product);
    // Product UpdateProduct(Product product, string id);
     Task<ProductDto> CreateProduct(CreateProductRequest createProduct);
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto> GetById(Guid id);


    Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request);
    Task<bool> DeleteProductAsync(Guid id);
}