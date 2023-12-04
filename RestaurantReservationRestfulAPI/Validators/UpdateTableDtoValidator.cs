using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class UpdateTableDtoValidator : AbstractValidator<UpdateTableDto>
{
    public UpdateTableDtoValidator()
    {
        RuleFor(table => table.Capacity).GreaterThan(0).WithMessage("Capacity must be more than zero!.");
    }
}