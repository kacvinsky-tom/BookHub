using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AssignCorrectAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[]
                {
                    "86718895-f083-4ba8-8452-b7a4dc9ca99c",
                    "0d8fb324-0996-465b-a7b1-aeaaf327e6a8"
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[]
                {
                    "86718895-f083-4ba8-8452-b7a4dc9ca99c",
                    "0d8fb324-0996-465b-a7b1-aeaaf327e6a8"
                }
            );
        }
    }
}
