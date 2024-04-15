using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class UpdateEmployeeDtoValidator : AbstractValidator<UpdateEmployeeDto>
{
    public UpdateEmployeeDtoValidator()
    {
        RuleFor(employee => employee.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(employee => employee.LastName).NotEmpty().WithMessage("Last name is required.");
    }
}