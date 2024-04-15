using FluentValidation;
using RestaurantReservation.API.ModelsDto;
using RestaurantReservation.Db.Models;
namespace RestaurantReservation.API.Validators;

public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidator()
    {
        RuleFor(employee => employee.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(employee => employee.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(employee => employee.Position)
          .NotEmpty().WithMessage("Position is required.")
          .IsEnumName(typeof(EmployeePositionEnum)).WithMessage("Invalid position.");
    }
}
