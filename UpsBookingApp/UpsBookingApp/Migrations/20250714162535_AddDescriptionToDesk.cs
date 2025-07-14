using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToDesk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Desks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Desks");
        }
    }
}
