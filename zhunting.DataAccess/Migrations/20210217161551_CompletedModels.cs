using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zhunting.DataAccess.Migrations
{
    public partial class CompletedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7bc14ed6-2fb1-4a20-bbe6-1f56ca725f45"));

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: new Guid("5f40a62b-067c-4425-9f41-edbbd100b980"));

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceInHuf = table.Column<double>(type: "float", nullable: false),
                    PriceInEur = table.Column<double>(type: "float", nullable: false),
                    Zone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Paragraph = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5f40a62b-067c-4425-9f41-edbbd100b980"), "Test Gallery" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "GalleryId", "Link" },
                values: new object[] { new Guid("7bc14ed6-2fb1-4a20-bbe6-1f56ca725f45"), new Guid("5f40a62b-067c-4425-9f41-edbbd100b980"), "https://thephotostudio.com.au/wp-content/uploads/2017/10/Emily-Ratajkowski-1.jpg" });
        }
    }
}
