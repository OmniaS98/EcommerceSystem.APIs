using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Data.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;  
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public double TotalPrice { get; set; }

    public Customer Customer { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; } = [];
}
