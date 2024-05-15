using EcommerceSystem.BL.DTOs.Products;
using EcommerceSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.Managers.Products;

public interface IProductManager
{
    IEnumerable<ProductReadDTO> GetAll(int? categoryId, string? productName);
    ProductDetailsDTO? GetWithDetails(int id);
}
