using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class CreateTableDtoValidator : AbstractValidator<CreateTableDto>
{
    public CreateTableDtoValidator()
    {
        RuleFor(table => table.Capacity).GreaterThan(0).WithMessage("Capacity must be more than zero!.");
    }
}