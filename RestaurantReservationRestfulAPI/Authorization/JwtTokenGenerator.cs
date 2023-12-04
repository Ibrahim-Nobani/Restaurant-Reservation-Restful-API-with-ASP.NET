using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
namespace RestaurantReservation.Authorization;

public class JwtTokenGenerator : ITokenService
{
    private readonly JwtTokenConfig _jwtTokenOptions;

    public JwtTokenGenerator(IOptions<JwtTokenConfig> jwtTokenOptions)
    {
        _jwtTokenOptions = jwtTokenOptions.Value ?? throw new ArgumentNullException(nameof(jwtTokenOptions));
    }

    public Task<string> GenerateTokenAsync()
    {

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "RestaurantReservation"),
        };

        var key = new SymmetricSecurityKey(Convert.FromBase64String(_jwtTokenOptions.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtTokenOptions.Issuer,
            _jwtTokenOptions.Audience,
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<TokenValidationResult> ValidateTokenAsync(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Convert.FromBase64String(_jwtTokenOptions.SecretKey));

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtTokenOptions.Issuer,
            ValidAudience = _jwtTokenOptions.Audience,
            IssuerSigningKey = key
        };

        return await tokenHandler.ValidateTokenAsync(token, validationParameters);
    }
}