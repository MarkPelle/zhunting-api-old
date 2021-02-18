using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zhunting.DataAccess.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5f40a62b-067c-4425-9f41-edbbd100b980"), "Test Gallery" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "GalleryId", "Link" },
                values: new object[] { new Guid("7bc14ed6-2fb1-4a20-bbe6-1f56ca725f45"), new Guid("5f40a62b-067c-4425-9f41-edbbd100b980"), "https://thephotostudio.com.au/wp-content/uploads/2017/10/Emily-Ratajkowski-1.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_GalleryId",
                table: "Images",
                column: "GalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Galleries");
        }
    }
}
