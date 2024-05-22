using EcommerceSystem.DAL.Data.Context;
using EcommerceSystem.DAL.Data.Models;
using EcommerceSystem.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories.Carts;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    
    public CartRepository(EcommerceContext context) : base(context)
    {
        
    }


    public Cart? GetByCustomerId(string cutomerId)
    {
        var cart = _context.Set<Cart>()
            .Include(c => c.Items)
            .FirstOrDefault(c => c.CustomerId == cutomerId);
        if(cart == null)
            return null;
        return cart;
    }

    public (bool available, string message) IsProductAvailable(Product product, int requiredQuantity)
    {
        if (product.Quantity == 0)
            return (false, "Out of stock");
        else if (product.Quantity < requiredQuantity)
            return (false, $"Quantity exceeds the available stock for Product ID: {product.Id}. Available quantity: {product.Quantity} units");

        return (true, "");
    }



}
