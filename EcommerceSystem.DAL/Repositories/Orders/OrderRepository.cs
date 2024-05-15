using EcommerceSystem.DAL.Data.Context;
using EcommerceSystem.DAL.Data.Models;
using EcommerceSystem.DAL.Repositories.Generic;
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
}
