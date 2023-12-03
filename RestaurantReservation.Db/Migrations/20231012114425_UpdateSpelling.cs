using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Restaurants_RestaurantResturantId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantResturantId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantResturantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_RestaurantResturantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_RestaurantResturantId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RestaurantResturantId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RestaurantResturantId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "RestaurantResturantId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "RestaurantResturantId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ResturantId",
                table: "Tables",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "ResturantId",
                table: "Restaurants",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "ResturantId",
                table: "MenuItems",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "ResturantId",
                table: "Employees",
                newName: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RestaurantId",
                table: "Employees",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Restaurants_RestaurantId",
                table: "Employees",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                table: "Tables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Restaurants_RestaurantId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RestaurantId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Tables",
                newName: "ResturantId");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Restaurants",
                newName: "ResturantId");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "MenuItems",
                newName: "ResturantId");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Employees",
                newName: "ResturantId");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantResturantId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantResturantId",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantResturantId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantResturantId",
                table: "Tables",
                column: "RestaurantResturantId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantResturantId",
                table: "MenuItems",
                column: "RestaurantResturantId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RestaurantResturantId",
                table: "Employees",
                column: "RestaurantResturantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Restaurants_RestaurantResturantId",
                table: "Employees",
                column: "RestaurantResturantId",
                principalTable: "Restaurants",
                principalColumn: "ResturantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantResturantId",
                table: "MenuItems",
                column: "RestaurantResturantId",
                principalTable: "Restaurants",
                principalColumn: "ResturantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantResturantId",
                table: "Tables",
                column: "RestaurantResturantId",
                principalTable: "Restaurants",
                principalColumn: "ResturantId");
        }
    }
}
