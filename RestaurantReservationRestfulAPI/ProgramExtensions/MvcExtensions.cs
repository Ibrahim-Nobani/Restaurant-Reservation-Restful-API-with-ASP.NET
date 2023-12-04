using FluentValidation;
using FluentValidation.AspNetCore;
using RestaurantReservation.API.Filters;

public static class MvcExtensions
{
    public static void AddCustomMvc(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program));

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<Program>();

        services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
        }).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    }

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "RestaurantReservation.API", Version = "v1" });
        });
    }
}
