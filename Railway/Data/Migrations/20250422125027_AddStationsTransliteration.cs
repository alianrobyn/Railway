#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Railway.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStationsTransliteration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdditionPrice",
                table: "TicketTypes",
                newName: "AdditionCost");

            migrationBuilder.AddColumn<string>(
                name: "TransliteratedName",
                table: "Stations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransliteratedName",
                table: "Stations");

            migrationBuilder.RenameColumn(
                name: "AdditionCost",
                table: "TicketTypes",
                newName: "AdditionPrice");
        }
    }
}
