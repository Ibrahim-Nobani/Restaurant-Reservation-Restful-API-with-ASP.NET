using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Order> Orders { get; set; }
    }
}