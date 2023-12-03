using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedureFindCustomersByPartySize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    CREATE PROCEDURE sp_FindCustomersByPartySize
                        @PartySize INT
                    AS
                    BEGIN
                        SELECT c.*
                        FROM Customers c
                        INNER JOIN Reservations r
                        on r.CustomerId = c.CustomerId
                        WHERE r.PartySize > @PartySize
                    END
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_FindCustomersByPartySize");
        }
    }
}
