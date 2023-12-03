using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
namespace RestaurantReservation.Db
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    RestaurantId = 1,
                    Name = "Restaurant A",
                    Address = "123 Main St",
                    PhoneNumber = "555-123-4567",
                    OpeningHours = "9:00 AM - 10:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 2,
                    Name = "Restaurant B",
                    Address = "456 Elm St",
                    PhoneNumber = "555-987-6543",
                    OpeningHours = "8:00 AM - 9:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 3,
                    Name = "Restaurant C",
                    Address = "789 Oak St",
                    PhoneNumber = "555-555-5555",
                    OpeningHours = "10:00 AM - 11:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 4,
                    Name = "Restaurant D",
                    Address = "567 Pine St",
                    PhoneNumber = "555-777-8888",
                    OpeningHours = "8:30 AM - 9:30 PM"
                },
                new Restaurant
                {
                    RestaurantId = 5,
                    Name = "Restaurant E",
                    Address = "321 Cedar St",
                    PhoneNumber = "555-444-3333",
                    OpeningHours = "11:00 AM - 10:00 PM"
                }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table
                {
                    TableId = 1,
                    Capacity = 4,
                    RestaurantId = 1
                },
                new Table
                {
                    TableId = 2,
                    Capacity = 6,
                    RestaurantId = 1
                },
                new Table
                {
                    TableId = 3,
                    Capacity = 5,
                    RestaurantId = 2
                },
                new Table
                {
                    TableId = 4,
                    Capacity = 4,
                    RestaurantId = 3
                },
                new Table
                {
                    TableId = 5,
                    Capacity = 6,
                    RestaurantId = 4
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "555-111-1111"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "555-222-2222"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    PhoneNumber = "555-333-3333"
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Bob",
                    LastName = "Williams",
                    Email = "bob.williams@example.com",
                    PhoneNumber = "555-444-4444"
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "Eve",
                    LastName = "Brown",
                    Email = "eve.brown@example.com",
                    PhoneNumber = "555-555-5555"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    Position = "Server",
                    RestaurantId = 1
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sarah",
                    LastName = "Davis",
                    Position = "Chef",
                    RestaurantId = 2
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "David",
                    LastName = "Lee",
                    Position = "Bartender",
                    RestaurantId = 1
                },
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Emily",
                    LastName = "Smith",
                    Position = "Server",
                    RestaurantId = 3
                },
                new Employee
                {
                    EmployeeId = 5,
                    FirstName = "John",
                    LastName = "Wilson",
                    Position = "Manager",
                    RestaurantId = 4
                }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    MenuItemId = 1,
                    Name = "Burger",
                    Description = "Juicy beef burger with cheese",
                    Price = 9.99M,
                    RestaurantId = 1
                },
                new MenuItem
                {
                    MenuItemId = 2,
                    Name = "Spaghetti Carbonara",
                    Description = "Creamy pasta with bacon and eggs",
                    Price = 12.99M,
                    RestaurantId = 2
                },
                new MenuItem
                {
                    MenuItemId = 3,
                    Name = "Margherita Pizza",
                    Description = "Classic tomato and mozzarella pizza",
                    Price = 10.99M,
                    RestaurantId = 1
                },
                new MenuItem
                {
                    MenuItemId = 4,
                    Name = "Chicken Alfredo",
                    Description = "Creamy pasta with chicken and Alfredo sauce",
                    Price = 13.99M,
                    RestaurantId = 3
                },
                new MenuItem
                {
                    MenuItemId = 5,
                    Name = "Sushi Platter",
                    Description = "Assorted sushi rolls and sashimi",
                    Price = 15.99M,
                    RestaurantId = 4
                }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderItemId = 1,
                    Quantity = 2,
                    OrderId = 1,
                    MenuItemId = 1
                },
                new OrderItem
                {
                    OrderItemId = 2,
                    Quantity = 1,
                    OrderId = 1,
                    MenuItemId = 3
                },
                new OrderItem
                {
                    OrderItemId = 3,
                    Quantity = 3,
                    OrderId = 2,
                    MenuItemId = 2
                },
                new OrderItem
                {
                    OrderItemId = 4,
                    Quantity = 1,
                    OrderId = 3,
                    MenuItemId = 4
                },
                new OrderItem
                {
                    OrderItemId = 5,
                    Quantity = 2,
                    OrderId = 4,
                    MenuItemId = 5
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                    TotalAmount = 50.00M,
                    ReservationId = 1,
                    EmployeeId = 1
                },
                new Order
                {
                    OrderId = 2,
                    OrderDate = DateTime.Now,
                    TotalAmount = 40.00M,
                    ReservationId = 2,
                    EmployeeId = 2
                },
                new Order
                {
                    OrderId = 3,
                    OrderDate = DateTime.Now,
                    TotalAmount = 30.00M,
                    ReservationId = 3,
                    EmployeeId = 3
                },
                new Order
                {
                    OrderId = 4,
                    OrderDate = DateTime.Now,
                    TotalAmount = 60.00M,
                    ReservationId = 4,
                    EmployeeId = 4
                },
                new Order
                {
                    OrderId = 5,
                    OrderDate = DateTime.Now,
                    TotalAmount = 45.00M,
                    ReservationId = 5,
                    EmployeeId = 5
                }
            );

            modelBuilder.Entity<Reservation>().HasData(
               new Reservation
               {
                   ReservationId = 1,
                   ReservationDate = DateTime.Now.AddDays(2),
                   PartySize = 4,
                   TableId = 1,
                   CustomerId = 1,
                   RestaurantId = 1
               },
               new Reservation
               {
                   ReservationId = 2,
                   ReservationDate = DateTime.Now.AddDays(3),
                   PartySize = 6,
                   TableId = 2,
                   CustomerId = 2,
                   RestaurantId = 2
               },
               new Reservation
               {
                   ReservationId = 3,
                   ReservationDate = DateTime.Now.AddDays(4),
                   PartySize = 2,
                   TableId = 3,
                   CustomerId = 3,
                   RestaurantId = 3
               },
               new Reservation
               {
                   ReservationId = 4,
                   ReservationDate = DateTime.Now.AddDays(5),
                   PartySize = 3,
                   TableId = 4,
                   CustomerId = 4,
                   RestaurantId = 4
               },
               new Reservation
               {
                   ReservationId = 5,
                   ReservationDate = DateTime.Now.AddDays(6),
                   PartySize = 5,
                   TableId = 5,
                   CustomerId = 5,
                   RestaurantId = 5
               }
           );
        }
    }
}
