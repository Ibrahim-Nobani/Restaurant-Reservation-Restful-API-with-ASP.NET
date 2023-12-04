using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemDtoValidator()
    {
        RuleFor(orderItem => orderItem.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity must be more than zero!.");
    }
}