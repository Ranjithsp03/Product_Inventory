using AutoMapper;
using AutoMapper.Internal.Mappers;
using ProductsInventory.Api.Data.DTOs;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Models.Requests;
using ProductsInventory.Api.Repositories;

namespace ProductsInventory.Api.Services;

public class ProductService : IproductService
{
    private IproductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IproductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;

    }
    public async Task<ProductDto> CreateProduct(CreateProductRequest createProduct)
    {
        var product = _mapper.Map<Product>(createProduct);
        await _productRepository.AddAsync(product);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetProductsAsync();
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }

    public async Task<ProductDto> GetById(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

     public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = _productRepository.GetByIdAsync(id);
        if(product is null)
        {
            return false;
        }
        await _productRepository.DeleteAsync(id);
        return true;

    }
     public async Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return null;
        }

        _mapper.Map(request, product);
        await _productRepository.UpdateAsync(product);

        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }


    // public Product AddProduct(Product product)
    // {
    //     return _productRepository.Save(product);
    // }

    // public void DeleteProduct(string id)
    // {

    //     Product product = _productRepository.Get(id);
    //     if (product == null)
    //     {
    //         throw new Exception("Product not found");
    //     }
    //     _productRepository.RemoveProduct(id);
    // }

    // public List<Product> GetAllProducts()
    // {
    //     return _productRepository.GetAll();
    // }

    // public Product GetProduct(string id)
    // {
    //     return _productRepository.Get(id);
    // }


    // public Product UpdateProduct(string id,Product product)
    // {
    //     Product dpproduct = _productRepository.Get(id);
    //     if (dpproduct == null)
    //     {
    //         throw new Exception("Produc not found");
    //     }
    //     if (product.Name != "")
    //     {
    //         dpproduct.Name = product.Name;
    //     }
    //     Product updatedproduct=_productRepository.UpdateProduct(id,dpproduct);
    //     return updatedproduct;
    // }

    // public Product UpdateProduct(strProduct product)
    // {
    //     throw new Exception("Produc not found");
    // }
}
