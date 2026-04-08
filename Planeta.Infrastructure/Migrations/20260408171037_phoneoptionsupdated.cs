using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planeta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class phoneoptionsupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatteryCapacity",
                table: "PhoneOptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BatteryHealth",
                table: "PhoneOptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryCapacity",
                table: "PhoneOptions");

            migrationBuilder.DropColumn(
                name: "BatteryHealth",
                table: "PhoneOptions");
        }
    }
}
