using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using abc.Entities;
using Microsoft.EntityFrameworkCore;
// using System.Text.Json.Serialization;
namespace ProductsInventory.Api.Models;
[Table("Products")]
public class Product
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(50)]//Data validations
    public required string Name { get; set; }
  
    public int Quantity { get; set; }
    [Precision(6,2)]
    public double Price { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public List<Category>?Categories{ get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
    public Product()
    {
        // Id = "0000";
        // Name = "Unknown";
    }
    public Product(string id, string name, int quantity, double price)
    {
        // Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
    }

}