using Microsoft.IdentityModel.Tokens;
namespace RestaurantReservation.Authorization;

public interface ITokenService
{
    Task<string> GenerateTokenAsync();
    Task<TokenValidationResult> ValidateTokenAsync(string token);
}