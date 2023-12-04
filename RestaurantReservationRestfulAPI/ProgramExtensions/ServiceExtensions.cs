using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Authorization;
using RestaurantReservation.Repositories;
using RestaurantReservation.Services;
using RestaurantReservation.ServicesInterfaces;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<CustomerService>();

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<EmployeeService>();

        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<RestaurantService>();

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<OrderService>();

        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<OrderItemService>();

        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<MenuItemService>();

        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<TableService>();

        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<ReservationService>();
    }

    public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantReservationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString"));
        });
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
    }

    public static void AddCustomJWT(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenService, JwtTokenGenerator>();
        services.Configure<JwtTokenConfig>(configuration.GetSection("JWTToken"));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var jwtConfig = configuration.GetSection("JWTToken").Get<JwtTokenConfig>() ?? throw new ArgumentNullException("JWTToken:Wrong Configuration");
                var key = new SymmetricSecurityKey(Convert.FromBase64String(jwtConfig.SecretKey));

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = key
                };
            });

        services.AddAuthorization();
    }
}