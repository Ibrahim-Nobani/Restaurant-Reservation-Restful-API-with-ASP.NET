using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class seedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "555-111-1111" },
                    { 2, "jane.smith@example.com", "Jane", "Smith", "555-222-2222" },
                    { 3, "alice.johnson@example.com", "Alice", "Johnson", "555-333-3333" },
                    { 4, "bob.williams@example.com", "Bob", "Williams", "555-444-4444" },
                    { 5, "eve.brown@example.com", "Eve", "Brown", "555-555-5555" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Restaurant A", "9:00 AM - 10:00 PM", "555-123-4567" },
                    { 2, "456 Elm St", "Restaurant B", "8:00 AM - 9:00 PM", "555-987-6543" },
                    { 3, "789 Oak St", "Restaurant C", "10:00 AM - 11:00 PM", "555-555-5555" },
                    { 4, "567 Pine St", "Restaurant D", "8:30 AM - 9:30 PM", "555-777-8888" },
                    { 5, "321 Cedar St", "Restaurant E", "11:00 AM - 10:00 PM", "555-444-3333" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Michael", "Johnson", "Server", 1 },
                    { 2, "Sarah", "Davis", "Chef", 2 },
                    { 3, "David", "Lee", "Bartender", 1 },
                    { 4, "Emily", "Smith", "Server", 3 },
                    { 5, "John", "Wilson", "Manager", 4 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Juicy beef burger with cheese", "Burger", 9.99m, 1 },
                    { 2, "Creamy pasta with bacon and eggs", "Spaghetti Carbonara", 12.99m, 2 },
                    { 3, "Classic tomato and mozzarella pizza", "Margherita Pizza", 10.99m, 1 },
                    { 4, "Creamy pasta with chicken and Alfredo sauce", "Chicken Alfredo", 13.99m, 3 },
                    { 5, "Assorted sushi rolls and sashimi", "Sushi Platter", 15.99m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 6, 1 },
                    { 3, 5, 2 },
                    { 4, 4, 3 },
                    { 5, 6, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 10, 14, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5533), 1, 1 },
                    { 2, 2, 6, new DateTime(2023, 10, 15, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5539), 2, 2 },
                    { 3, 3, 2, new DateTime(2023, 10, 16, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5542), 3, 3 },
                    { 4, 4, 3, new DateTime(2023, 10, 17, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5544), 4, 4 },
                    { 5, 5, 5, new DateTime(2023, 10, 18, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5548), 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 12, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5451), 1, 50.00m },
                    { 2, 2, new DateTime(2023, 10, 12, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5505), 2, 40.00m },
                    { 3, 3, new DateTime(2023, 10, 12, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5508), 3, 30.00m },
                    { 4, 4, new DateTime(2023, 10, 12, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5511), 4, 60.00m },
                    { 5, 5, new DateTime(2023, 10, 12, 16, 38, 6, 717, DateTimeKind.Local).AddTicks(5513), 5, 45.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 3, 1, 1 },
                    { 3, 2, 2, 3 },
                    { 4, 4, 3, 1 },
                    { 5, 5, 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);
        }
    }
}
