using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class primary_genre_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 1 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 7, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 2 },
                column: "IsPrimary",
                value: true
            );

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 11, 2 },
                column: "IsPrimary",
                value: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValues: new object[] { 2, 2 },
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
                keyValues: new object[] { 4, 1 },
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
                keyValues: new object[] { 6, 2 },
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
                keyValues: new object[] { 8, 2 },
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
                keyValues: new object[] { 10, 2 },
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
        }
    }
}
