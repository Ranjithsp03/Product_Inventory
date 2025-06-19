using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsInventory.Api.Models;
using abc.Entities;
using ProductsInventory.Api.Data.DTOs;
using AuthApp.Entities;
namespace ProductsInventory.Api.Data;

public class ApplicationDpContext : DbContext
{
    public DbSet<Product> products { get; set; }
    public DbSet<User> Users { get; set; }
    public ApplicationDpContext(DbContextOptions<ApplicationDpContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasIndex(u=> u.Username)
            .IsUnique();
            // .Property(c => c.Categories)
            // .HasConversion(
            //     new ValueConverter<List<Category>, string>(
            //         value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null),
            //         static value => JsonSerializer.Deserialize<List<Category>>(value, (JsonSerializerOptions?)null) ?? new List<Category>()
            //     )
            // )
            // .Metadata.SetValueComparer(
            //     new ValueComparer<List<Category>>(
            //         (c1, c2) => c1.SequenceEqual(c2),
            //         c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            //         c => c.ToList()
            //     )
            // );


    }
}