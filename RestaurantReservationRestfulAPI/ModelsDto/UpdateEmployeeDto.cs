namespace RestaurantReservation.API.ModelsDto
{
    public class UpdateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int RestaurantId { get; set; }
    }
}