using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class book_genre_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6807
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6811
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6813
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6814
                )
            );

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 8 },
                    { 2, 2 },
                    { 2, 8 },
                    { 3, 2 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 1 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 5, 2 },
                    { 5, 8 },
                    { 6, 2 },
                    { 6, 8 },
                    { 7, 2 },
                    { 7, 8 },
                    { 8, 2 },
                    { 8, 8 },
                    { 9, 2 },
                    { 9, 8 },
                    { 10, 2 },
                    { 10, 8 },
                    { 11, 2 },
                    { 11, 8 }
                }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6821
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6853
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6857
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6859
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6862
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6866
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6868
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6871
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6873
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6877
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6879
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6925
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6927
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6929
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6778
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6781
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6782
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6784
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6786
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6790
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6791
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6793
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6795
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6797
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6799
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6801
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6803
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6804
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6940
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6943
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6945
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6947
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6932
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6935
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6937
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6906
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6909
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6911
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6913
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6914
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6917
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6919
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6920
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6717
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6762
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6769
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6772
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6893
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6896
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6897
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6899
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6901
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6903
                )
            );

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6886
                )
            );

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 20, 21, 46, 31, 590, DateTimeKind.Local).AddTicks(
                    6889
                )
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 1, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 1, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 2, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 2, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 3, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 3, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 3, 9 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 4, 1 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 4, 5 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 4, 6 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 4, 7 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 5, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 5, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 6, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 6, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 7, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 7, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 8, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 8, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 9, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 9, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 10, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 10, 8 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 11, 2 }
            );

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 11, 8 }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2391
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2395
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2397
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2399
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2405
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2413
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2416
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2418
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2421
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2425
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2453
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2457
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2460
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2463
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2466
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2512
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2515
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2517
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2360
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2363
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2365
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2367
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2368
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2373
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2375
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2377
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2378
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2381
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2383
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2385
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2386
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2388
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2527
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2530
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2533
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2535
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2519
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2522
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2524
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2492
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2496
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2498
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2500
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2502
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2504
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2506
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2508
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2302
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2348
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2351
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2354
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2479
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2482
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2484
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2485
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2487
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2489
                )
            );

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2472
                )
            );

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(
                    2476
                )
            );
        }
    }
}
