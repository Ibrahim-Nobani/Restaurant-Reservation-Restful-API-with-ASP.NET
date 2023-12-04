using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeeWithRestaurantDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW EmployeeWithRestaurantDetails AS
            SELECT
                e.EmployeeId AS EmployeeId,
                e.FirstName AS EmployeeFirstName,
                e.LastName AS EmployeeLastName,
                e.Position AS EmployeePosition,
                r.RestaurantId AS RestaurantId,
                r.Name AS RestaurantName
            FROM Employees e
            JOIN Restaurants r ON e.RestaurantId = r.RestaurantId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW EmployeeWithRestaurantDetails");
        }
    }
}
