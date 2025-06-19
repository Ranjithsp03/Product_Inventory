using System.ComponentModel.DataAnnotations;

namespace AuthApp.Entities;

public class User
{
    [Key]
    public Guid Id { get; set;}
    [Required]
    [MaxLength(50)]
    public required string Username {get; set;}
    [Required]
    public string Password { get; set;}

    public string Role { get; set;}
}