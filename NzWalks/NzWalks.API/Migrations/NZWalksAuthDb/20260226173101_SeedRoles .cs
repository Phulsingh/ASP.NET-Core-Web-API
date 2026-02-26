using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalks.API.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f1b6829-bcc4-4d81-90ee-3283d769aa1b", "0f1b6829-bcc4-4d81-90ee-3283d769aa1b", "Reader", "READER" },
                    { "b8be6f6f-bb9c-4fca-bea5-5003c77e9f44", "b8be6f6f-bb9c-4fca-bea5-5003c77e9f44", "Writer", "WRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f1b6829-bcc4-4d81-90ee-3283d769aa1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8be6f6f-bb9c-4fca-bea5-5003c77e9f44");
        }
    }
}
