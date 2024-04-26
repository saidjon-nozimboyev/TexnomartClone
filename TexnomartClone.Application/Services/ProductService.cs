using FluentValidation;
using System.Net;
using TexnomartClone.Application.Common.Exceptions;
using TexnomartClone.Application.Common.Validators;
using TexnomartClone.Application.DTOs.ProductDTOs;
using TexnomartClone.Application.Interfaces;
using TexnomartClone.Data.Interfaces;
using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Application.Services;

public class ProductService(IUnitOfWork unitOfWork,
                            IValidator<Product> validator) 
    : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Product> _validator = validator;

    public async Task CreateAsync(AddProductDto dto)
    {
        if (dto is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Dto can not be null");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        await _unitOfWork.Product.CreateAsync(dto);
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _unitOfWork.Product.GetByIdAsync(id);
        if (product is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Product with this id not found");

        await _unitOfWork.Product.DeleteAsync(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _unitOfWork.Product.GetAllAsync();
        return products.Select(x => (ProductDto)x).ToList();
    }

    public Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByPriceAsync(double price)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProductDto dto)
    {
        throw new NotImplementedException();
    }
}
