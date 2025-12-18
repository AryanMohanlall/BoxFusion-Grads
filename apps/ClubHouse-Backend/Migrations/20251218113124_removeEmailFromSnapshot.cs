using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubHouse.Backend.Migrations
{
    /// <inheritdoc />
    public partial class removeEmailFromSnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProfileSnapshots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProfileSnapshots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
