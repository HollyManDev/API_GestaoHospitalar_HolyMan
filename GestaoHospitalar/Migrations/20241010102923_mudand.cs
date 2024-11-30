using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class mudand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camas_Leitos_LeitoID",
                table: "Camas");

            migrationBuilder.AlterColumn<int>(
                name: "LeitoID",
                table: "Camas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Camas_Leitos_LeitoID",
                table: "Camas",
                column: "LeitoID",
                principalTable: "Leitos",
                principalColumn: "LeitoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camas_Leitos_LeitoID",
                table: "Camas");

            migrationBuilder.AlterColumn<int>(
                name: "LeitoID",
                table: "Camas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Camas_Leitos_LeitoID",
                table: "Camas",
                column: "LeitoID",
                principalTable: "Leitos",
                principalColumn: "LeitoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
