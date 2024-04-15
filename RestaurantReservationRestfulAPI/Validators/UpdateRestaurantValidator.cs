using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class UpdateRestaurantDtoValidator : AbstractValidator<UpdateRestaurantDto>
{
    public UpdateRestaurantDtoValidator()
    {
        RuleFor(restaurant => restaurant.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(restaurant => restaurant.Address).NotEmpty().WithMessage("Last name is required.");
        RuleFor(restaurant => restaurant.PhoneNumber).Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$").WithMessage("Invalid phone number.");
    }
}