using ProductsInventory.Api.Models;

namespace ProductsInventory.Api.Repositories;

public interface IproductRepository
{
    // public Product Save(Product product);
    // public List<Product> GetAll();
    // public Product Get(string id);
    // public Product UpdateProduct(string id,Product product);
    // public void RemoveProduct(string id);

     Task<Product> AddAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task DeleteAsync(Guid id);
        Task<Product> GetByIdAsync(Guid id);
        Task UpdateAsync(Product product);
}