using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.ModelsDto
{
    public class CreateRestaurantDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OpeningHours { get; set; }
    }
}