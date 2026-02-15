using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NzWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class lengthinKMtableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LengthInKm",
                table: "Walks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LengthInKm",
                table: "Walks");
        }
    }
}
