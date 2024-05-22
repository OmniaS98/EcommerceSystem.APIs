using EcommerceSystem.BL.DTOs.Carts;
using EcommerceSystem.BL.DTOs.Orders;
using EcommerceSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.Managers.Orders;

public interface IOrderManager
{
     public OrderDTO CreateOrder(string userId, List<OrderItemRequestDTO> items);
}
