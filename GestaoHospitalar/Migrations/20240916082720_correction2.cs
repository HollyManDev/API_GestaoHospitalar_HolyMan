using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class correction2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioMedicamentos_Pacientes_PacienteID",
                table: "InventarioMedicamentos");

            migrationBuilder.DropIndex(
                name: "IX_InventarioMedicamentos_PacienteID",
                table: "InventarioMedicamentos");

            migrationBuilder.DropColumn(
                name: "PacienteID",
                table: "InventarioMedicamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteID",
                table: "InventarioMedicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventarioMedicamentos_PacienteID",
                table: "InventarioMedicamentos",
                column: "PacienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioMedicamentos_Pacientes_PacienteID",
                table: "InventarioMedicamentos",
                column: "PacienteID",
                principalTable: "Pacientes",
                principalColumn: "PacienteID");
        }
    }
}
