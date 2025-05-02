using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectName.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    vin = table.Column<string>(type: "CHAR(17)", maxLength: 17, nullable: false),
                    model_year = table.Column<int>(type: "INTEGER", nullable: false),
                    colour = table.Column<string>(type: "TEXT", nullable: false),
                    user_email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    model = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    manufacturer = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    sale_date = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.vin);
                });

            migrationBuilder.CreateTable(
                name: "model",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    manufacturer_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_model", x => x.id);
                    table.ForeignKey(
                        name: "FK_Model_Manufacturer",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

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

            migrationBuilder.CreateIndex(
                name: "FK_Model_Manufacturer",
                table: "model",
                column: "manufacturer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "model");

            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "manufacturer");
        }
    }
}
