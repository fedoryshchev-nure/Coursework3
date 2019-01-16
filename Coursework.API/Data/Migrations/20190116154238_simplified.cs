using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class simplified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WallMaterial");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Sensors",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<string>(
                name: "MaterialId",
                table: "Walls",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Walls_MaterialId",
                table: "Walls",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walls_Materials_MaterialId",
                table: "Walls",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walls_Materials_MaterialId",
                table: "Walls");

            migrationBuilder.DropIndex(
                name: "IX_Walls_MaterialId",
                table: "Walls");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Walls");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Sensors",
                newName: "Password");

            migrationBuilder.CreateTable(
                name: "WallMaterial",
                columns: table => new
                {
                    MaterialId = table.Column<string>(nullable: false),
                    WallId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallMaterial", x => new { x.MaterialId, x.WallId });
                    table.ForeignKey(
                        name: "FK_WallMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WallMaterial_Walls_WallId",
                        column: x => x.WallId,
                        principalTable: "Walls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WallMaterial_WallId",
                table: "WallMaterial",
                column: "WallId");
        }
    }
}
