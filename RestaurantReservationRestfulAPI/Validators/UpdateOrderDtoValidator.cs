using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(order => order.TotalAmount).GreaterThan(0).WithMessage("Total Amount must be more than zero!.");
        RuleFor(order => order.OrderDate).Must(IsAValidDateInFuture).WithMessage("Order Date must be a valid date in the future!");
    }

    private bool IsAValidDateInFuture(DateTime orderDate)
    {
        return orderDate > DateTime.Now;
    }
}