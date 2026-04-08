using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planeta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImeiPropNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IMEI",
                table: "Products",
                newName: "Imei");

            migrationBuilder.AlterColumn<string>(
                name: "Imei",
                table: "Products",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imei",
                table: "Products",
                newName: "IMEI");

            migrationBuilder.AlterColumn<string>(
                name: "IMEI",
                table: "Products",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);
        }
    }
}
