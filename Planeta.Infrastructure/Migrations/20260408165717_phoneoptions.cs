using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Planeta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class phoneoptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imei",
                table: "Products",
                newName: "IMEI");

            migrationBuilder.AddColumn<int>(
                name: "PhoneOptionsId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhoneOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneOptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PhoneOptionsId",
                table: "Products",
                column: "PhoneOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PhoneOptions_PhoneOptionsId",
                table: "Products",
                column: "PhoneOptionsId",
                principalTable: "PhoneOptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PhoneOptions_PhoneOptionsId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PhoneOptions");

            migrationBuilder.DropIndex(
                name: "IX_Products_PhoneOptionsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhoneOptionsId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "IMEI",
                table: "Products",
                newName: "Imei");
        }
    }
}
