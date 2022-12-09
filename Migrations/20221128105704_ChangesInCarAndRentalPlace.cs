using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsRent.Migrations
{
    public partial class ChangesInCarAndRentalPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localization",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "Cars",
                newName: "RentalPlaceId");

            migrationBuilder.CreateTable(
                name: "RentalPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPlaces", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RentalPlaces",
                columns: new[] { "Id", "BasePrice", "City" },
                values: new object[] { 1, 70, "Krakow" });

            migrationBuilder.InsertData(
                table: "RentalPlaces",
                columns: new[] { "Id", "BasePrice", "City" },
                values: new object[] { 2, 120, "Rzeszow" });

            migrationBuilder.InsertData(
                table: "RentalPlaces",
                columns: new[] { "Id", "BasePrice", "City" },
                values: new object[] { 3, 100, "Warszawa" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "RentalPlaceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "RentalPlaceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "RentalPlaceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "RentalPlaceId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentalPlaceId",
                table: "Cars",
                column: "RentalPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RentalPlaces_RentalPlaceId",
                table: "Cars",
                column: "RentalPlaceId",
                principalTable: "RentalPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RentalPlaces_RentalPlaceId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "RentalPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RentalPlaceId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "RentalPlaceId",
                table: "Cars",
                newName: "BasePrice");

            migrationBuilder.AddColumn<string>(
                name: "Localization",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BasePrice", "Localization" },
                values: new object[] { 90, "Rzeszów" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BasePrice", "Localization" },
                values: new object[] { 100, "Warszawa" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BasePrice", "Localization" },
                values: new object[] { 250, "Tarnów" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BasePrice", "Localization" },
                values: new object[] { 10, "Kraków" });
        }
    }
}
