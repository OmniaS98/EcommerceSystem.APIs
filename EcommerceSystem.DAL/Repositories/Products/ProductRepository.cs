using EcommerceSystem.DAL.Data.Context;
using EcommerceSystem.DAL.Data.Models;
using EcommerceSystem.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(EcommerceContext context) : base(context)
    {
    }
}
