using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class OrderItemsNullabilityFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER"
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6207
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6211
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6213
                )
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6215
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6221
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6227
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6230
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6233
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6236
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6240
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6242
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6245
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6248
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6252
                )
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6254
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6323
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6325
                )
            );

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6327
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6176
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6179
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6181
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6183
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6185
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6188
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6190
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6191
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6194
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6196
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6198
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6200
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6202
                )
            );

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6204
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6341
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6346
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6348
                )
            );

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6350
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6330
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6333
                )
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6335
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6302
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6307
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6309
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6312
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6314
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6316
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6318
                )
            );

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6320
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6113
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6162
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6166
                )
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6170
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6289
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6292
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6294
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6295
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6297
                )
            );

            migrationBuilder.UpdateData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6300
                )
            );

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6282
                )
            );

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 19, 57, 38, 747, DateTimeKind.Local).AddTicks(
                    6286
                )
            );
        }
    }
}
