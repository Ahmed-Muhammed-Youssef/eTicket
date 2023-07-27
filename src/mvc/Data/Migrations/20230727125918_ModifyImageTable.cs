using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Image",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Image",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Image",
                type: "nvarchar(50)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
