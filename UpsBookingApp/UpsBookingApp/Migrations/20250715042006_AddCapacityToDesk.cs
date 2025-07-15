using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCapacityToDesk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Desks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Desks");
        }
    }
}
