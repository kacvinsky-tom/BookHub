using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class Vouchers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoucherUsedId",
                table: "Orders",
                type: "INTEGER",
                nullable: true
            );

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        Code = table.Column<string>(type: "TEXT", nullable: false),
                        Discount = table.Column<int>(type: "INTEGER", nullable: false),
                        ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                        Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                        Type = table.Column<int>(type: "INTEGER", nullable: false),
                        CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                        UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                }
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "VoucherUsedId",
                value: null
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "VoucherUsedId",
                value: null
            );

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "VoucherUsedId",
                value: null
            );

            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[]
                {
                    "Id",
                    "Code",
                    "CreatedAt",
                    "Discount",
                    "ExpirationDate",
                    "Quantity",
                    "Type",
                    "UpdatedAt"
                },
                values: new object[,]
                {
                    {
                        1,
                        "VANOCE10",
                        new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                        10,
                        new DateTime(2023, 12, 24, 12, 0, 0, 0, DateTimeKind.Unspecified),
                        0,
                        0,
                        null
                    },
                    {
                        2,
                        "KILODOLU",
                        new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                        100,
                        new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        0,
                        1,
                        null
                    },
                    {
                        3,
                        "ZIMNISLEVA",
                        new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                        20,
                        new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        0,
                        0,
                        null
                    }
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VoucherUsedId",
                table: "Orders",
                column: "VoucherUsedId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Vouchers_VoucherUsedId",
                table: "Orders",
                column: "VoucherUsedId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vouchers_VoucherUsedId",
                table: "Orders"
            );

            migrationBuilder.DropTable(name: "Vouchers");

            migrationBuilder.DropIndex(name: "IX_Orders_VoucherUsedId", table: "Orders");

            migrationBuilder.DropColumn(name: "VoucherUsedId", table: "Orders");
        }
    }
}
