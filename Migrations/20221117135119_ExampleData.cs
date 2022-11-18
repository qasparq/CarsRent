using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsRent.Migrations
{
    public partial class ExampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarType",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarAvaible", "CarType", "Combustion", "Localization", "Name" },
                values: new object[,]
                {
                    { 1, 3, 13, 9f, "Rzeszów", "Audi" },
                    { 2, 9, 20, 12f, "Warszawa", "BMW" },
                    { 3, 1, 10, 5f, "Tarnów", "Chevrolet" },
                    { 4, 1, 16, 21f, "Kraków", "Polonez" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CarType",
                table: "Cars");
        }
    }
}
