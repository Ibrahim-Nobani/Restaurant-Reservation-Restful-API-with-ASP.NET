using FluentValidation;
using RestaurantReservation.API.ModelsDto;
namespace RestaurantReservation.API.Validators;

public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
{
    public CreateReservationDtoValidator()
    {
        RuleFor(reservation => reservation.PartySize).GreaterThan(0).WithMessage("Party Size must be more than zero!.");
        RuleFor(reservation => reservation.ReservationDate).Must(IsAValidDateInFuture).WithMessage("Reservation Date must be a valid date in the future!");
    }

    private bool IsAValidDateInFuture(DateTime reservationDate)
    {
        return reservationDate > DateTime.Now;
    }
}