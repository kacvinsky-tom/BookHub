using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Postgre.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cd0b4d6-355c-4016-ade3-fd4ae514eded"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51132739-e370-4fc2-88fa-cae0afaaf6b8"
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86718895-f083-4ba8-8452-b7a4dc9ca99c", null, "Admin", "ADMIN" },
                    { "cb9a0fb7-cd3e-498f-9b3e-ef3c9809708d", null, "User", "USER" }
                }
            );

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[]
                {
                    "Id",
                    "AccessFailedCount",
                    "ConcurrencyStamp",
                    "Email",
                    "EmailConfirmed",
                    "LockoutEnabled",
                    "LockoutEnd",
                    "NormalizedEmail",
                    "NormalizedUserName",
                    "PasswordHash",
                    "PhoneNumber",
                    "PhoneNumberConfirmed",
                    "SecurityStamp",
                    "TwoFactorEnabled",
                    "UserId",
                    "UserName"
                },
                values: new object[,]
                {
                    {
                        "0d8fb324-0996-465b-a7b1-aeaaf327e6a8",
                        0,
                        "52f29df2-7b85-4f2d-b925-d861e125ad37",
                        "john.doe@gmail.com",
                        true,
                        false,
                        null,
                        "JOHN.DOE@GMAIL.COM",
                        "JOHN.DOE",
                        "AQAAAAIAAYagAAAAENvJRIhW0HvRBoR6q6bmwLyxK6FOQd+ENX5fY0zExhUbq9q8JsCo8Gz0CxOH5O6xCA==",
                        null,
                        false,
                        "e34b0df2-8863-4466-ae5a-92686ddb52e4",
                        false,
                        1,
                        "john.doe"
                    },
                    {
                        "551d86f0-c626-4dcf-bb4e-5fb3d05666cd",
                        0,
                        "2ca69a27-f75d-4b17-89e1-e3a4c9da44d9",
                        "jane.doe@gmai.com",
                        true,
                        false,
                        null,
                        "JANE.DOE@GMAI.COM",
                        "JANE.DOE",
                        "AQAAAAIAAYagAAAAEAEyiPBPZx6HbMCOq2MmaqxdciGpSUbhoX01VRjU4hGjXRdOh3ou7Lg3QwhfcRkA3w==",
                        null,
                        false,
                        "4bac5dda-ba34-433d-9f68-0bd4abf58c1c",
                        false,
                        2,
                        "jane.doe"
                    },
                    {
                        "996aa4ee-3b11-4e0f-b307-63bad603f850",
                        0,
                        "f350415d-efed-44bf-b92c-8e61f19b2469",
                        "pavel.kraus@gmail.com",
                        true,
                        false,
                        null,
                        "PAVEL.KRAUS@GMAIL.COM",
                        "PAVEL.KRAUS",
                        "AQAAAAIAAYagAAAAEJa0udvFKhAgafmNjFzwoPR4YnCskaTHKP0CmpjH2h4BOOWz4kHEO3EF8JjGcLrUpg==",
                        null,
                        false,
                        "51f9b5e5-8609-4c04-9800-500cfee2f599",
                        false,
                        3,
                        "pavel.kraus"
                    },
                    {
                        "caac826e-f9a3-4d6f-a521-e35be632b112",
                        0,
                        "cdedf214-b574-4988-86c3-81a44173688a",
                        "jarda@novak.cz",
                        true,
                        false,
                        null,
                        "JARDA@NOVAK.CZ",
                        "JARDA.NOVAK",
                        "AQAAAAIAAYagAAAAEJJZ5PWdW8XhdfuYU6UkWnkqBwOcsPHWIErN+0r6boR5bc2QMD750v7PB2cL4NLeIA==",
                        null,
                        false,
                        "fe71b0a1-d7fa-4017-a0f1-95b23f05f8fe",
                        false,
                        4,
                        "jarda.novak"
                    }
                }
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86718895-f083-4ba8-8452-b7a4dc9ca99c"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb9a0fb7-cd3e-498f-9b3e-ef3c9809708d"
            );

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d8fb324-0996-465b-a7b1-aeaaf327e6a8"
            );

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "551d86f0-c626-4dcf-bb4e-5fb3d05666cd"
            );

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "996aa4ee-3b11-4e0f-b307-63bad603f850"
            );

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "caac826e-f9a3-4d6f-a521-e35be632b112"
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cd0b4d6-355c-4016-ade3-fd4ae514eded", null, "User", "USER" },
                    { "51132739-e370-4fc2-88fa-cae0afaaf6b8", null, "Admin", "ADMIN" }
                }
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
