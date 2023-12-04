using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateFunctionRestaurantTotalRevenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE FUNCTION CalculateTotalRevenueByRestaurant (@restaurantId INT)
            RETURNS DECIMAL(10, 2)
            AS
            BEGIN
                DECLARE @totalRevenue DECIMAL(10, 2);

                SELECT @totalRevenue = SUM(o.TotalAmount)
                FROM Orders o
                INNER JOIN Reservations r ON o.ReservationId = r.ReservationId
                WHERE r.RestaurantId = @restaurantId;

                RETURN @totalRevenue;
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION CalculateTotalRevenueByRestaurant;");
        }
    }
}
