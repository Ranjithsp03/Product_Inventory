
using ProductsInventory.Api.Data.DTOs;
using AutoMapper;
using ProductsInventory.Api.Models.Requests;
using AuthApp.Entities;
namespace ProductsInventory.Api.Models;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();
        CreateMap<UserDto, User>().ReverseMap();//if two names /passwords are same
        
    }
}