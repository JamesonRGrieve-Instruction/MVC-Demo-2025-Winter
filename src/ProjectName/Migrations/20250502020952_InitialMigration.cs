using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectName.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicle");
        }
    }
}
