using EcommerceSystem.BL.DTOs.Customers;
using EcommerceSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceSystem.APIs.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UsersController: ControllerBase
{
    private readonly UserManager<Customer> _userManager;
    private readonly IConfiguration _configuration;

    public UsersController(UserManager<Customer> userManager, IConfiguration configuration) 
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register(RegisterDTO registerDto)
    {
        var user = new Customer
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if(!result.Succeeded)
            return BadRequest(result.Errors);

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName),
            new (ClaimTypes.Email, user.Email)
        };

        await _userManager.AddClaimsAsync(user, claims);

        return Created("", new
        {
            userName =user.UserName,
            Email = user.Email
        });

    }

    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDto)
    {

        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if(user == null)
            return Unauthorized();

        bool isAuthenticated = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!isAuthenticated)
            return Unauthorized();

        var userClaims = await _userManager.GetClaimsAsync(user);

        return GenerateToken(userClaims);
    }


    
    private ActionResult<TokenDTO> GenerateToken(IEnumerable<Claim> userClaims)
    {
        var keyFromConfig = _configuration.GetValue<string>(Constants.AppSettings.SecretKey);
        var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig!);
        var key = new SymmetricSecurityKey(keyInBytes);
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var expiryDate = DateTime.Now.AddMinutes(10);

        var jwt = new JwtSecurityToken(
            claims: userClaims,
            signingCredentials: signingCredentials,
            expires: expiryDate);

        var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);
        return new TokenDTO(jwtAsString, expiryDate);
    }

}
 