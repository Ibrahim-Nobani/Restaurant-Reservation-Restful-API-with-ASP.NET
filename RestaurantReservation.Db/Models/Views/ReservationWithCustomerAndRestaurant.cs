namespace RestaurantReservation.Db.Models
{
    public class ReservationsWithCustomerAndRestaurant
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}
