using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant;
    }
}