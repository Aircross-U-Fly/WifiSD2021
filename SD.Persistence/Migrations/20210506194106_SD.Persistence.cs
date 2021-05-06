using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SD.Persistence.Migrations
{
    public partial class SDPersistence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediumType",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediumType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    MediumTypeCode = table.Column<string>(type: "nvarchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_MediumType_MediumTypeCode",
                        column: x => x.MediumTypeCode,
                        principalTable: "MediumType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Horror" },
                    { 3, "Sience Fiction" },
                    { 4, "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "MediumType",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "BR", "Blue Ray" },
                    { "BR4K", "Blue Ray 4K" },
                    { "BR3D", "Blue Ray 3D" },
                    { "BRHDR", "Blue Ray HD" },
                    { "DVD", "Digital Versitale Disc" },
                    { "ST", "Streaming" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "GenreId", "MediumTypeCode", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("9443e96b-41b3-42c9-9aa7-6ce5c5f92c00"), 3, "BR", "Star Wars - Episode IV", 9.99m, new DateTime(1987, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("af6301d0-f9d5-461b-b675-d247a78f9904"), 3, "BR3D", "Star Trek - Beyond", 6.34m, new DateTime(2016, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64f024f6-f145-417b-afbd-5cb2f4967911"), 1, "DVD", "Rambo", 4.99m, new DateTime(1985, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7fb72af0-bbe0-4e43-97bc-aa4f10390ede"), 2, "ST", "The Ring", 4.50m, new DateTime(2005, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MediumTypeCode",
                table: "Movies",
                column: "MediumTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Name",
                table: "Movies",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MediumType");
        }
    }
}
