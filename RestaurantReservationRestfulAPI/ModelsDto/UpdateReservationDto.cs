namespace RestaurantReservation.API.ModelsDto
{
    public class UpdateReservationDto
    {
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public int TableId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
    }
}