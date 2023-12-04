using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Authorization;
namespace MinimalWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenGenerator;

    public AuthController(ITokenService tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost("token")]
    public async Task<IActionResult> GenerateToken()
    {
        var token = await _tokenGenerator.GenerateTokenAsync();

        if (token == null)
        {
            return Unauthorized();
        }
        
        return Ok(new { Token = token });
    }
}