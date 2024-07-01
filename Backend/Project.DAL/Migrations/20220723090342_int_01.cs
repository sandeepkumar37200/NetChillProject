using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class int_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreaterdAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Category = table.Column<string>(maxLength: 255, nullable: false),
                    YOR = table.Column<DateTime>(nullable: false),
                    AvailableDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 8000, nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    MoviesPoster = table.Column<string>(nullable: true),
                    ContentPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreaterdAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(maxLength: 225, nullable: false),
                    EmailId = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    SubscriptionStatus = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreaterdAt", "EmailId", "FullName", "IsAdmin", "PasswordHash", "PasswordSalt", "SubscriptionStatus", "UpdatedAt" },
                values: new object[] { new Guid("f0ec5135-eb77-4ac1-a15a-514b56fd976c"), new DateTime(2022, 7, 23, 9, 3, 42, 513, DateTimeKind.Utc).AddTicks(7668), "admin1@netchill.com", "admin1", true, new byte[] { 26, 124, 96, 130, 49, 109, 1, 89, 50, 106, 180, 127, 193, 163, 2, 47, 39, 165, 63, 229, 68, 152, 114, 29, 56, 244, 132, 206, 163, 25, 120, 252, 189, 48, 71, 44, 63, 245, 238, 30, 28, 250, 126, 124, 41, 210, 42, 197, 128, 106, 217, 143, 189, 206, 152, 144, 203, 207, 31, 192, 149, 102, 145, 100 }, new byte[] { 33, 252, 11, 72, 150, 35, 203, 139, 78, 144, 95, 119, 105, 178, 115, 255, 21, 191, 254, 131, 159, 149, 33, 32, 47, 114, 200, 157, 205, 173, 68, 167, 56, 247, 225, 171, 164, 92, 97, 103, 4, 109, 29, 238, 243, 46, 152, 204, 37, 47, 18, 133, 131, 207, 37, 20, 120, 200, 16, 21, 180, 62, 139, 160, 54, 238, 149, 56, 67, 222, 149, 171, 148, 24, 118, 61, 190, 89, 156, 200, 66, 22, 78, 127, 87, 162, 43, 54, 114, 229, 189, 169, 253, 14, 6, 205, 77, 102, 73, 218, 146, 47, 132, 74, 68, 60, 40, 36, 122, 104, 228, 50, 61, 29, 100, 85, 100, 160, 101, 188, 244, 95, 251, 68, 61, 95, 15, 160 }, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreaterdAt", "EmailId", "FullName", "IsAdmin", "PasswordHash", "PasswordSalt", "SubscriptionStatus", "UpdatedAt" },
                values: new object[] { new Guid("c4aabae1-5e98-4010-a54e-0fafba0062b7"), new DateTime(2022, 7, 23, 9, 3, 42, 513, DateTimeKind.Utc).AddTicks(8718), "admin2@netchill.com", "admin2", true, new byte[] { 26, 124, 96, 130, 49, 109, 1, 89, 50, 106, 180, 127, 193, 163, 2, 47, 39, 165, 63, 229, 68, 152, 114, 29, 56, 244, 132, 206, 163, 25, 120, 252, 189, 48, 71, 44, 63, 245, 238, 30, 28, 250, 126, 124, 41, 210, 42, 197, 128, 106, 217, 143, 189, 206, 152, 144, 203, 207, 31, 192, 149, 102, 145, 100 }, new byte[] { 33, 252, 11, 72, 150, 35, 203, 139, 78, 144, 95, 119, 105, 178, 115, 255, 21, 191, 254, 131, 159, 149, 33, 32, 47, 114, 200, 157, 205, 173, 68, 167, 56, 247, 225, 171, 164, 92, 97, 103, 4, 109, 29, 238, 243, 46, 152, 204, 37, 47, 18, 133, 131, 207, 37, 20, 120, 200, 16, 21, 180, 62, 139, 160, 54, 238, 149, 56, 67, 222, 149, 171, 148, 24, 118, 61, 190, 89, 156, 200, 66, 22, 78, 127, 87, 162, 43, 54, 114, 229, 189, 169, 253, 14, 6, 205, 77, 102, 73, 218, 146, 47, 132, 74, 68, 60, 40, 36, 122, 104, 228, 50, 61, 29, 100, 85, 100, 160, 101, 188, 244, 95, 251, 68, 61, 95, 15, 160 }, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MovieId",
                table: "UserMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
