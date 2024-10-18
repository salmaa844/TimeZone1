using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeZone.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class deletNameSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Slides");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
