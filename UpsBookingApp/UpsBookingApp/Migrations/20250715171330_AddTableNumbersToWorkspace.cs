using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableNumbersToWorkspace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Workspaces");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Workspaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
