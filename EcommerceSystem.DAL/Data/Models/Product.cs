using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Data.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    // Reference navigation 
    public Category Category { get; set; } = null!;
    public List<CartItem> CartItem { get; set; } = [];
    public List<OrderItem> OrderItem { get; set; } = [];
}
