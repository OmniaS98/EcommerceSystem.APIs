using EcommerceSystem.DAL.Data.Models;
using EcommerceSystem.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories.Orders;

public interface IOrderRepository:IGenericRepository<Order>
{
    public List<Order> GetAllWithDetails(string userId);
}
