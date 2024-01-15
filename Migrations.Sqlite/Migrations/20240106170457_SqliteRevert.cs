using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class SqliteRevert : Migration
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

            migrationBuilder.DropForeignKey(name: "FK_BookGenre_Books_BookId", table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_GenreId",
                table: "BookGenre"
            );

            migrationBuilder.DropColumn(name: "IsAdmin", table: "Users");

            migrationBuilder.DropColumn(name: "Password", table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "BookGenre",
                type: "INTEGER",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(
                        type: "TEXT",
                        maxLength: 256,
                        nullable: true
                    ),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(
                        type: "TEXT",
                        maxLength: 256,
                        nullable: true
                    ),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(
                        type: "TEXT",
                        maxLength: 256,
                        nullable: true
                    ),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserLogins",
                        x => new { x.LoginProvider, x.ProviderKey }
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserTokens",
                        x => new
                        {
                            x.UserId,
                            x.LoginProvider,
                            x.Name
                        }
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
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

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc)
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc)
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc)
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId"
            );

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId"
            );

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true
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
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor"
            );

            migrationBuilder.DropForeignKey(name: "FK_BookGenre_Books_BookId", table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_GenreId",
                table: "BookGenre"
            );

            migrationBuilder.DropTable(name: "AspNetRoleClaims");

            migrationBuilder.DropTable(name: "AspNetUserClaims");

            migrationBuilder.DropTable(name: "AspNetUserLogins");

            migrationBuilder.DropTable(name: "AspNetUserRoles");

            migrationBuilder.DropTable(name: "AspNetUserTokens");

            migrationBuilder.DropTable(name: "AspNetRoles");

            migrationBuilder.DropTable(name: "AspNetUsers");

            migrationBuilder.DropColumn(name: "IsPrimary", table: "BookGenre");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsAdmin", "Password" },
                values: new object[]
                {
                    true,
                    "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi"
                }
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsAdmin", "Password" },
                values: new object[]
                {
                    false,
                    "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi"
                }
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsAdmin", "Password" },
                values: new object[]
                {
                    false,
                    "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi"
                }
            );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsAdmin", "Password" },
                values: new object[]
                {
                    false,
                    "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi"
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
