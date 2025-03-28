using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNET_Console_Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "manufacturer",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -4, "Nissan" },
                    { -3, "Toyota" },
                    { -2, "Honda" },
                    { -1, "Mitsubishi" }
                });

            migrationBuilder.InsertData(
                table: "model",
                columns: new[] { "id", "manufacturer_id", "name" },
                values: new object[,]
                {
                    { -8, -4, "GTR" },
                    { -7, -4, "300ZX" },
                    { -6, -3, "MR2" },
                    { -5, -3, "Supra" },
                    { -4, -2, "S2000" },
                    { -3, -2, "NSX" },
                    { -2, -1, "3000GT" },
                    { -1, -1, "Eclipse" }
                });

            migrationBuilder.InsertData(
                table: "vehicle",
                columns: new[] { "vin", "colour", "model_id", "model_year" },
                values: new object[,]
                {
                    { "-----BCNR33004655", "Purple", -8, 1995 },
                    { "4A3AL54F3XE067712", "Red", -1, 1999 },
                    { "JA3AN74K8XY001384", "Red", -2, 1999 },
                    { "JH4NA1153MT000743", "Silver", -3, 1991 },
                    { "JHMAP21475S008443", "Steel Blue", -4, 2005 },
                    { "JN1RZ24A1LX002317", "Red", -7, 1990 },
                    { "JT2JA82J8S0028274", "Black", -5, 1995 },
                    { "JTDFR320320052403", "Green", -6, 2002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "-----BCNR33004655");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "4A3AL54F3XE067712");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "JA3AN74K8XY001384");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "JH4NA1153MT000743");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "JHMAP21475S008443");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "JN1RZ24A1LX002317");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "JT2JA82J8S0028274");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "JTDFR320320052403");

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "manufacturer",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "manufacturer",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "manufacturer",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "manufacturer",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
