using EcommerceSystem.BL.DTOs.Carts;
using EcommerceSystem.BL.DTOs.Orders;
using EcommerceSystem.BL.Managers.Carts;
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
    public OrderDTO CreateOrder(string userId, List<OrderItemRequestDTO> items)
    {
        double totalPrice = 0;
        var orderList = new List<OrderItem>();
        var orderListDTO = new List<OrderItemDTO>();


        foreach (var item in items)
        {
            var product = _unitOfWork.ProductRepository.GetById(item.ProductId);

            if (product == null)
            {
                throw new Exception($"No product with Id: {item.ProductId}");
            }


            //Check product availability
            var isAvailable = _unitOfWork.CartRepository.IsProductAvailable(product, item.Quantity);

            if (!isAvailable.available)
            {
                throw new Exception(isAvailable.message);
            }

            //Update product quantity
            product.Quantity -= item.Quantity;

            double price = item.Quantity * product.Price;
            totalPrice += price;

            orderList.Add(new OrderItem()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });

            orderListDTO.Add(new OrderItemDTO()
            {
                ProductId = item.ProductId,
                ProductName = product.Name,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            });
        }

        
        //Add new order
        var newOrder = new Order
        {
            CustomerId = userId,
            CreatedDate = DateTime.Now,
            TotalPrice = totalPrice,
            OrderItems = orderList
        };

        _unitOfWork.OrderRepository.Add(newOrder);
        _unitOfWork.SaveChanges();

        var orderDTO = new OrderDTO
        {
            CustomerId = newOrder.CustomerId,
            OrderDate = newOrder.CreatedDate,
            Items = orderListDTO,
            TotalPrice = newOrder.TotalPrice
        };

        return orderDTO;
        

    }
}
