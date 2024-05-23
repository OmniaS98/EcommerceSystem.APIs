using EcommerceSystem.BL.DTOs.Carts;
using EcommerceSystem.BL.DTOs.Orders;
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
    public async Task<ActionResult> PlaceOrder(List<OrderItemDTO> items)
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);
            var order = _orderManager.CreateOrder(user!.Id, items);
            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }

    [Authorize]
    [HttpGet]
    [Route("history")]
    public async Task<ActionResult> History()
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = _orderManager.ViewHistory(user!.Id);
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }


}
