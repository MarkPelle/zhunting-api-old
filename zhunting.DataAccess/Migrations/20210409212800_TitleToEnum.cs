using Microsoft.EntityFrameworkCore.Migrations;

namespace zhunting.DataAccess.Migrations
{
    public partial class TitleToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Contacts",
                type: "nvarchar(50)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Contacts",
                type: "int",
                nullable: true,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
