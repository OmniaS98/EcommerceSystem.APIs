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
    public OrderDTO CreateOrder(string userId, List<OrderItemDTO> items)
    {
        double totalPrice = 0;
        var orderList = new List<OrderItem>();
        var orderListDTO = new List<OrderItemResponseDTO>();


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

            orderListDTO.Add(new OrderItemResponseDTO()
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
            OrderDate = newOrder.CreatedDate,
            Items = orderListDTO,
            TotalPrice = newOrder.TotalPrice
        };

        return orderDTO;
        

    }

    
        public List<OrderHistoryDTO> ViewHistory(string userId)
        {
            List<Order> orders = _unitOfWork.OrderRepository.GetAllWithDetails(userId);
            List<OrderHistoryDTO> orderDTOs = orders.Select(o => new OrderHistoryDTO
            {
                OrderId = o.Id,
                OrderDate = o.CreatedDate,
                Items = o.OrderItems.Select(i => new OrderItemDTO
                {
                    ProductId= i.ProductId,
                    Quantity = i.Quantity
   
                }).ToList(),

                TotalPrice = o.TotalPrice
            }).ToList();

            return orderDTOs;
    }
}
