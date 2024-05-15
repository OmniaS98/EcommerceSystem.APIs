using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Data.Models;

public class Cart
{
    public int Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;

    public Customer Cutomer { get; set; } = null!;
    public List<CartItem> Items { get; set; } = [];
}
