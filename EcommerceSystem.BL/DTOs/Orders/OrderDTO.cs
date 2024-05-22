using EcommerceSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.DTOs.Orders;

public class OrderDTO
{
    public string CustomerId { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<OrderItemDTO> Items { get; set; } = [];
    public double TotalPrice { get; set; }
}
