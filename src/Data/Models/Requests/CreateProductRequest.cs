using abc.Entities;
namespace ProductsInventory.Api.Models.Requests;

using ProductsInventory.Api.Models;
public class CreateProductRequest
{
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public List<Category>? Categories{ get; set; }
}