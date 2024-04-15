namespace RestaurantReservation.API.ModelsDto
{
    public class UpdateMenuItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
    }
}