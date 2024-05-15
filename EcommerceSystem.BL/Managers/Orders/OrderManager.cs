using EcommerceSystem.BL.DTOs.Carts;
using EcommerceSystem.BL.DTOs.Orders;
using EcommerceSystem.DAL;
using EcommerceSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.Managers.Orders;

public class OrderManager : IOrderManager
{
    private readonly IUnitOfWork _unitOfWork;
    public OrderManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Order CreateOrder( string userId, List<CartItemDTO> items)
    {
        var userCart = _unitOfWork.CartRepository.GetByCustomerId(userId);
        if (userCart == null || userCart.Items.Count == 0)
        {
            throw new Exception("The user's cart is empty.");
        }

        double totalPrice = 0;
        List<CartItem> orderList = [];

       foreach (var item in items)
       { 

            //double price = item.Quantity * product.Price;
            //totalPrice += price;
       }

        var newOrder = new Order
        {
            CustomerId = userId,
            TotalPrice = totalPrice,
            //CartItems = orderList
        };

        _unitOfWork.OrderRepository.Add(newOrder);

        _unitOfWork.SaveChanges();
        return newOrder;
    }
}
