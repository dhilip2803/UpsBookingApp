using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableNumberToWorkspace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkspaceBooking");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Workspaces");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Workspaces",
                newName: "IsAvailable");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Workspaces",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Workspaces",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Workspaces",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Workspaces",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkspaceBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkspaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspaceBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkspaceBooking_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkspaceBooking_WorkspaceId",
                table: "WorkspaceBooking",
                column: "WorkspaceId");
        }
    }
}
