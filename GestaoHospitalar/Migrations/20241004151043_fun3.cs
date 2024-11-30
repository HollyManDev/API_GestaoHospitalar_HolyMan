using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class fun3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargoID",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoID",
                table: "Funcionarios",
                column: "CargoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Cargos_CargoID",
                table: "Funcionarios",
                column: "CargoID",
                principalTable: "Cargos",
                principalColumn: "CargoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Cargos_CargoID",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_CargoID",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CargoID",
                table: "Funcionarios");
        }
    }
}
