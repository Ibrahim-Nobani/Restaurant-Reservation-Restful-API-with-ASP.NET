using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateViewReservationsWithCustomerAndRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
        CREATE VIEW ReservationsWithCustomerAndRestaurants AS
        SELECT
            r.ReservationId,
            r.CustomerId,
            c.FirstName AS CustomerFirstName,
            r.RestaurantId,
            re.Name AS RestaurantName
        FROM Reservations r
        INNER JOIN Customers c ON r.CustomerId = c.CustomerId
        INNER JOIN Restaurants re ON r.RestaurantId = re.RestaurantId;
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW ReservationsWithCustomerAndRestaurants;");
        }
    }
}
