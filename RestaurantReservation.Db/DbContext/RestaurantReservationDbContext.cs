using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<ReservationsWithCustomerAndRestaurant> ReservationsWithCustomerAndRestaurants { get; set; }
    public DbSet<EmployeeWithRestaurantDetails> EmployeeWithRestaurantDetails { get; set; }

    public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationsWithCustomerAndRestaurant>().HasNoKey().ToView(nameof(ReservationsWithCustomerAndRestaurants));
        modelBuilder.Entity<EmployeeWithRestaurantDetails>().HasNoKey().ToView(nameof(EmployeeWithRestaurantDetails));

        modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }
}