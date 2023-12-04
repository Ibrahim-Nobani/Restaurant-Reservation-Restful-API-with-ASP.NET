namespace RestaurantReservation.Db.Models
{
    public class EmployeeWithRestaurantDetails
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeePosition { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}
