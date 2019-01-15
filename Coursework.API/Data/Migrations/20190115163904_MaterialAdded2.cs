using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MaterialAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materials",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Name",
                table: "Materials",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Materials_Name",
                table: "Materials");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materials",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
