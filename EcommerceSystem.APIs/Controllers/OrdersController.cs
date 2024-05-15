﻿using EcommerceSystem.BL.DTOs.Carts;
using EcommerceSystem.BL.Managers.Orders;
using EcommerceSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSystem.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController: ControllerBase
{
    private readonly UserManager<Customer> _userManager;
    private readonly IOrderManager _orderManager;
    public OrdersController(UserManager<Customer> userManager, IOrderManager orderManager)
    {
        _userManager = userManager;
        _orderManager = orderManager;
    }

    [Authorize]
    [HttpPost]
    [Route("placeOrder")]
    public async Task<ActionResult> PlaceOrder(List<CartItemDTO> items)
    {
        try
        {
            var user = await  _userManager.GetUserAsync(User);
            var order = _orderManager.CreateOrder(user!.Id, items);
            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }
    

}
