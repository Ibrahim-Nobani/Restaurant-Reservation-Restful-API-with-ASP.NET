using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Order> Orders { get; set; }
    }
}