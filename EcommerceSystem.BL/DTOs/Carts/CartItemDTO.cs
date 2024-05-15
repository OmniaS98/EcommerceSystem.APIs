using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.DTOs.Carts;

public class CartItemDTO
{
    public int ProductId { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid value")]
    public int Quantity { get; set; }
}

