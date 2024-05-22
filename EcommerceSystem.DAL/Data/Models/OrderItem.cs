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
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    //Navigation properties
    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}
