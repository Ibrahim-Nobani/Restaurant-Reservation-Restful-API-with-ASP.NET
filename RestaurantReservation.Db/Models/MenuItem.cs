using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}