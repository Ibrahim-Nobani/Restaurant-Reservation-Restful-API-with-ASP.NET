namespace RestaurantReservation.API.ModelsDto
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int ReservationId { get; set; }
        public int EmployeeId { get; set; }
    }
}
