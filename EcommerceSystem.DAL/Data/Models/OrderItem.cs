using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Data.Models;

public  class OrderItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid value")]
    public double Price {  get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid value")]
    public int Quantity { get; set; }
 
    public Order Order { get; set; } = null!;
}
