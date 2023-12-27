using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateUserProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d57a697-d25b-4990-a2d2-a22096849a83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6acacba3-c4d5-4be8-9d79-4c0aaba0735b");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cd0b4d6-355c-4016-ade3-fd4ae514eded", null, "User", "USER" },
                    { "51132739-e370-4fc2-88fa-cae0afaaf6b8", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cd0b4d6-355c-4016-ade3-fd4ae514eded");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51132739-e370-4fc2-88fa-cae0afaaf6b8");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d57a697-d25b-4990-a2d2-a22096849a83", null, "Admin", "ADMIN" },
                    { "6acacba3-c4d5-4be8-9d79-4c0aaba0735b", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsAdmin", "Password" },
                values: new object[] { true, "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsAdmin", "Password" },
                values: new object[] { false, "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsAdmin", "Password" },
                values: new object[] { false, "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsAdmin", "Password" },
                values: new object[] { false, "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi" });
        }
    }
}
