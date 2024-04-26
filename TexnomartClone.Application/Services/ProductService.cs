using FluentValidation;
using System.Net;
using TexnomartClone.Application.Common.Exceptions;
using TexnomartClone.Application.Common.Validators;
using TexnomartClone.Application.DTOs.ProductDTOs;
using TexnomartClone.Application.Interfaces;
using TexnomartClone.Data.Interfaces;
using TexnomartClone.Domain.Entities;
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

    //public async Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
    //{
    //    if (string.IsNullOrEmpty(categoryName))
    //        throw new StatusCodeException(HttpStatusCode.BadRequest, "Category name cannot be null or empty");

    //    // Assuming you have a Category enum
    //    if (!Enum.TryParse<Category>(categoryName, true, out var category))
    //        throw new StatusCodeException(HttpStatusCode.BadRequest, "Invalid category name");

    //    var products = await _unitOfWork.Product.GetAllAsync(p => p.CategoryId == category);
    //    return products;
    //}

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Product.GetByIdAsync(id);
        return product != null ? (ProductDto)product : null;
    }

    //public async Task<Product> GetByPriceAsync(double price)
    //{
    //    if (price <= 0)
    //        throw new StatusCodeException(HttpStatusCode.BadRequest, "Price must be greater than zero");

    //    var product = await _unitOfWork.Product(p => p.Price == price);
    //    return product;
    //}

    public async Task UpdateAsync(ProductDto dto)
    {
        if (dto is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Dto cannot be null");

        var existingProduct = await _unitOfWork.Product.GetByIdAsync(dto.Id);
        if (existingProduct is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Product not found");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        // Update the existing product with values from dto
        // ... (e.g., existingProduct.Name = dto.Name, etc.)

        await _unitOfWork.Product.UpdateAsync(existingProduct);
    }
}
