using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
{
    public UpdateCustomerDtoValidator()
    {
        RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(customer => customer.Email).EmailAddress().WithMessage("The email is invalid");
        RuleFor(customer => customer.PhoneNumber).Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$").WithMessage("Invalid phone number.");
    }
}