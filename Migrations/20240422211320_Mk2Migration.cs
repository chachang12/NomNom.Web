using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NomNom.Web.Migrations
{
    /// <inheritdoc />
    public partial class Mk2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d960e61-a644-4f66-8ade-78ce00c4809b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92594245-85ae-448f-8cdc-d1a6a80e38ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9b0185e-06f0-4242-80e8-f9eea23f4743");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "070778a9-61e0-4144-95c6-03a3dd9a4df6", null, "vendor", "vendor" },
                    { "d4aeaea3-fa90-4745-ab62-147cdca27ced", null, "admin", "admin" },
                    { "d5459344-0c36-4e44-bb7a-0247a2748f1a", null, "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "070778a9-61e0-4144-95c6-03a3dd9a4df6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4aeaea3-fa90-4745-ab62-147cdca27ced");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5459344-0c36-4e44-bb7a-0247a2748f1a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d960e61-a644-4f66-8ade-78ce00c4809b", null, "client", "client" },
                    { "92594245-85ae-448f-8cdc-d1a6a80e38ff", null, "vendor", "vendor" },
                    { "b9b0185e-06f0-4242-80e8-f9eea23f4743", null, "admin", "admin" }
                });
        }
    }
}
