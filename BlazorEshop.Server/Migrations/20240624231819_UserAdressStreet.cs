using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEshop.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserAdressStreet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Addresses",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Addresses",
                newName: "Firstname");
        }
    }
}
