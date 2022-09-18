using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapiMoto.Migrations
{
    public partial class Inicial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tecnico_HitorialTecnico_HitorialTecnicoId",
                table: "Tecnico");

            migrationBuilder.DropIndex(
                name: "IX_Tecnico_HitorialTecnicoId",
                table: "Tecnico");

            migrationBuilder.DropColumn(
                name: "HitorialTecnicoId",
                table: "Tecnico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HitorialTecnicoId",
                table: "Tecnico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tecnico_HitorialTecnicoId",
                table: "Tecnico",
                column: "HitorialTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnico_HitorialTecnico_HitorialTecnicoId",
                table: "Tecnico",
                column: "HitorialTecnicoId",
                principalTable: "HitorialTecnico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
