using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_BookGenre_Books_BookId", table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_GenreId",
                table: "BookGenre"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43d5e5c0-1282-4349-b5e8-90668bc767dd"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef370c18-32ae-4666-b0be-690460dea024"
            );

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "BookGenre",
                type: "boolean",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d57a697-d25b-4990-a2d2-a22096849a83", null, "Admin", "ADMIN" },
                    { "6acacba3-c4d5-4be8-9d79-4c0aaba0735b", null, "User", "USER" }
                }
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 9 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 1 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 5 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 6 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 7 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 7, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 7, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 11, 2 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 11, 8 },
                column: "IsPrimary",
                value: false
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Books_BookId",
                table: "BookGenre",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Genres_GenreId",
                table: "BookGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_BookGenre_Books_BookId", table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_GenreId",
                table: "BookGenre"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d57a697-d25b-4990-a2d2-a22096849a83"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6acacba3-c4d5-4be8-9d79-4c0aaba0735b"
            );

            migrationBuilder.DropColumn(name: "IsPrimary", table: "BookGenre");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43d5e5c0-1282-4349-b5e8-90668bc767dd", null, "User", "USER" },
                    { "ef370c18-32ae-4666-b0be-690460dea024", null, "Admin", "ADMIN" }
                }
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Books_BookId",
                table: "BookGenre",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Genres_GenreId",
                table: "BookGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
