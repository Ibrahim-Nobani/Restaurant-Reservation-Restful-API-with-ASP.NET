namespace RestaurantReservation.API.ModelsDto
{
    public class CreateOrderItemDto
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
    }
}