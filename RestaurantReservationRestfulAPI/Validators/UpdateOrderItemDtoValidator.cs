using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class UpdateOrderItemDtoValidator : AbstractValidator<UpdateOrderItemDto>
{
    public UpdateOrderItemDtoValidator()
    {
        RuleFor(orderItem => orderItem.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity must be more than zero!.");
    }
}