using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class UpdateMenuItemDtoValidator : AbstractValidator<UpdateMenuItemDto>
{
    public UpdateMenuItemDtoValidator()
    {
        RuleFor(menuItem => menuItem.Name).NotEmpty().WithMessage("First name is required.");
        RuleFor(menuItem => menuItem.Price).GreaterThan(0).WithMessage("Price must be more than zero!.");
        RuleFor(menuItem => menuItem.Description).NotEmpty().WithMessage("Description is required");
    }
}