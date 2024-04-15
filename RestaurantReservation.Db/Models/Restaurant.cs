using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OpeningHours { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Table> Tables { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}