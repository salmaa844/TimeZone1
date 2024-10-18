using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeZone.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateimgSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgeName",
                table: "Slides",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgeName",
                table: "Slides");
        }
    }
}
