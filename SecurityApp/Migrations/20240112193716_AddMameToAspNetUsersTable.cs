using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecurityApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMameToAspNetUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mame",
                table: "AspNetUsers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Mame");
        }
    }
}
