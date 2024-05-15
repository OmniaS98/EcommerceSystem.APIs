using EcommerceSystem.BL.DTOs.Products;
using EcommerceSystem.BL.Managers.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSystem.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductManager _productManager;
    public ProductsController(IProductManager productManager)
    {
        _productManager = productManager;
    }

    // Retrieve all products
    // and make filteration by category id or product name if provided

    [Authorize]
    [HttpGet]
    public ActionResult<ProductReadDTO> GetAll([FromQuery]int? categoryId, [FromQuery] string? name)
    {
        var products =  _productManager.GetAll(categoryId, name);
        return Ok(products);
    }

    // Retrieve Product's details by id
    [HttpGet]
    [Route("{id}")]
    public ActionResult<ProductDetailsDTO> GetWithDetailsById(int id)
    {
        var product = _productManager.GetWithDetails(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

}
