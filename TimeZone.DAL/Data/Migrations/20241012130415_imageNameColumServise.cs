using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeZone.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class imageNameColumServise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgeName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgeName",
                table: "Services");
        }
    }
}
