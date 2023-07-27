using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Producer",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Movie",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Cinema",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Actor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 100, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producer_ImageId",
                table: "Producer",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ImageId",
                table: "Movie",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cinema_ImageId",
                table: "Cinema",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actor_ImageId",
                table: "Actor",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Image_ImageId",
                table: "Actor",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_Image_ImageId",
                table: "Cinema",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Image_ImageId",
                table: "Movie",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Producer_Image_ImageId",
                table: "Producer",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Image_ImageId",
                table: "Actor");

            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_Image_ImageId",
                table: "Cinema");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Image_ImageId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Producer_Image_ImageId",
                table: "Producer");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Producer_ImageId",
                table: "Producer");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ImageId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Cinema_ImageId",
                table: "Cinema");

            migrationBuilder.DropIndex(
                name: "IX_Actor_ImageId",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Producer");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Actor");
        }
    }
}
