using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRequest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTicketColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tickets",
                newName: "Object");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tickets",
                newName: "Content");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Object",
                table: "Tickets",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Tickets",
                newName: "Description");
        }
    }
}
