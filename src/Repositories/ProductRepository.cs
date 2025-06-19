using Microsoft.EntityFrameworkCore;
using ProductsInventory.Api.Data;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Repositories;
public class ProductRepository : IproductRepository
{
    // List<Product> products;
    public ApplicationDpContext _context;
    public ProductRepository(ApplicationDpContext applicationDpContext)

    {
        _context = applicationDpContext;
    }
    // public Product Get(string id)
    // {
    //     // var product = _context.products.Find(product => product.Id == id);
    //     Product product = _context.products.Find(id);
    //     return product;
    // }

    // public List<Product> GetAll()
    // {
    //     return _context.products.ToList<Product>();
    // }

    // public void RemoveProduct(string id)
    // {
    //     // var product = _context.products.Find(product => product.Id == id);
    //     Product product = _context.products.Find(id);
    //     _context.products.Remove(product);
    //     _context.SaveChanges();
    // }

    // public Product Save(Product product)
    // {
    //     _context.products.Add(product);
    //     _context.SaveChanges();
    //     return product;
    // }

    // public Product UpdateProduct(string id,Product product)
    // {
    //     _context.products.Update(product);
    //     _context.SaveChanges();
    //     return product;
    // }



    public async Task<Product> AddAsync(Product product)
    {
        await _context.products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.products.ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _context.products.FindAsync(id);
        if (product is null)
        {
            return;
        }

        _context.products.Remove(product);
        await _context.SaveChangesAsync();
        return;
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.products.FindAsync(id)!;
    }

    public async Task UpdateAsync(Product product)
    {
        var existingProduct = await _context.products.FindAsync(product.Id);
        if (existingProduct is null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        _context.Entry(existingProduct).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();
    }



    // Product IproductRepository.RemoveProduct(string id)
    // {
    //     throw new NotImplementedException();
    // }
}