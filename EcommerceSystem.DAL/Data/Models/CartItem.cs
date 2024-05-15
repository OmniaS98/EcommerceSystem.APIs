﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Data.Models;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid value")]
    public int Quantity { get; set; }

    //Navigation properties
    public Cart Cart { get; set; } = null!;
    public Product Product { get; set; } = null!;
}