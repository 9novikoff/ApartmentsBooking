using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentsBooking.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Ukraine" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Kyiv" });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentType", "CityId", "Description", "IsAvailable", "PrizePerHour" },
                values: new object[] { 1, 0, 1, null, true, 1m });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ApartmentId", "TimeFrom", "TimeTo", "UserId" },
                values: new object[] { 1, 1, new DateTime(2024, 5, 13, 18, 11, 5, 670, DateTimeKind.Local).AddTicks(5894), new DateTime(2024, 5, 23, 18, 11, 5, 670, DateTimeKind.Local).AddTicks(5935), "da9b5c6a-a9a1-4c56-a782-15e7fba86918" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
