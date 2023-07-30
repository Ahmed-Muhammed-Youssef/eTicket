using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePictureUrlFromProducer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "Producer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "Producer",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
