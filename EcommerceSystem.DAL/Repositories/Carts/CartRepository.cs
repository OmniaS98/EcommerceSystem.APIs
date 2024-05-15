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



}
