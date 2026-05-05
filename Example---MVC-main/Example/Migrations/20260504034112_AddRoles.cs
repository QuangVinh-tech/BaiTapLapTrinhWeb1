using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Example.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3846876f-d3a0-47d1-8148-8fa39ed2757a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90d36bec-a74a-43f2-a2b5-f90f972848fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5004a31-7a94-4d93-bba2-c9362499be6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a94727c-b5e5-444f-97a6-9241d683e978", null, "Admin", "ADMIN" },
                    { "ab3e0ee3-68a0-475e-824e-7447437c68c3", null, "User", "USER" },
                    { "faa4f621-9028-48db-b8dc-3d6244980fa4", null, "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a94727c-b5e5-444f-97a6-9241d683e978");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3e0ee3-68a0-475e-824e-7447437c68c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faa4f621-9028-48db-b8dc-3d6244980fa4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3846876f-d3a0-47d1-8148-8fa39ed2757a", null, "Editor", "EDITOR" },
                    { "90d36bec-a74a-43f2-a2b5-f90f972848fa", null, "Admin", "ADMIN" },
                    { "e5004a31-7a94-4d93-bba2-c9362499be6c", null, "User", "USER" }
                });
        }
    }
}
