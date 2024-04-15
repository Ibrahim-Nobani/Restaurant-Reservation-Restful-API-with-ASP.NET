namespace RestaurantReservation.Authorization;

public class JwtTokenConfig
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}