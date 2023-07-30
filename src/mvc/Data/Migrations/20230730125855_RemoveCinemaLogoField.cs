using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCinemaLogoField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Cinemas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Cinemas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
