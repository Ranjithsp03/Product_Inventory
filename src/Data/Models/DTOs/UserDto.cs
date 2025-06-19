using System.ComponentModel.DataAnnotations;

namespace AuthApp.Entities;

public class UserDto
{
    public required string Username {get; set;}
    public string Password { get; set;}

    public string Role { get; set;}
}