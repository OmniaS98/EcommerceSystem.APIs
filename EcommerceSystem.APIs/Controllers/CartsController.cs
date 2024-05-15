using EcommerceSystem.BL.DTOs.Carts;
using EcommerceSystem.BL.Managers.Carts;
using EcommerceSystem.DAL;
using EcommerceSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly UserManager<Customer> _userManager;
    private readonly ICartManager _cartManager;
    public CartsController(UserManager<Customer> userManager, ICartManager cartManager)
    {
        _userManager = userManager;
        _cartManager = cartManager;
    }


    [Authorize]
    [HttpPost]
    [Route("addItem")]
    public async Task<ActionResult> Add(CartItemDTO cartItemDto)
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);

            _cartManager.AddItem(user!.Id, cartItemDto);

            return Created();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [Authorize]
    [HttpDelete]
    [Route("removeItem")]
    public async Task<ActionResult> Remove([Required] int productId)
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);
            _cartManager.RemoveItem(user!.Id, productId);
            return Ok();
        }
        catch(Exception ex)
        {
           return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPut]
    [Route("editItemQuantity")]
    public async Task<ActionResult> EditQuantity(CartItemDTO cartItemDTO)
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);
            _cartManager.EditItemQuantity(user!.Id, cartItemDTO);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

} 
