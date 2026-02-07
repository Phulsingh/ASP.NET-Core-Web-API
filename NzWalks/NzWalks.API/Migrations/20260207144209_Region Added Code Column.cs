using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NzWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class RegionAddedCodeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Regions",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Regions",
                newName: "Description");
        }
    }
}
