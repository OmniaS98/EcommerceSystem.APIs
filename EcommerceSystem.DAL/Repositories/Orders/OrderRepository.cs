using EcommerceSystem.DAL.Data.Context;
using EcommerceSystem.DAL.Data.Models;
using EcommerceSystem.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories.Orders;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(EcommerceContext context) : base(context)
    {
    }

    public List<Order> GetAllWithDetails(string userId)
    {
        return _context.Set<Order>()
                .Include(o => o.OrderItems)
                .Where(o => o.CustomerId == userId )
                .AsNoTracking()
                .ToList();
    }
}
