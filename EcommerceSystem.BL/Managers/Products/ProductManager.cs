using EcommerceSystem.BL.DTOs.Products;
using EcommerceSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.Managers.Products;

public class ProductManager : IProductManager
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Get all products and make filteration if parameters are provided
    public IEnumerable<ProductReadDTO> GetAll(int? categoryId, string? productName)
    {
        var products = _unitOfWork.ProductRepository.GetAll().AsQueryable();
        if(categoryId != null)
        {
            return products.Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductReadDTO
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                });
        }

        if (productName != null)
        {
            return products.Where(p => p.Name.ToLower().Contains(productName.ToLower()))
                .Select(p => new ProductReadDTO
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                });
        }

        return products.Select(p => new ProductReadDTO
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        });
    }

    // Get Product details
    public ProductDetailsDTO? GetWithDetails(int id)
    {
        var product = _unitOfWork.ProductRepository.GetById(id);

        if (product is null)
            return null;

        return new ProductDetailsDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}
