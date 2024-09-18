using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class Correcting_TypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leitos_Pacientes_PacienteID",
                table: "Leitos");

            migrationBuilder.DropIndex(
                name: "IX_Leitos_PacienteID",
                table: "Leitos");

            migrationBuilder.DropColumn(
                name: "PacienteID",
                table: "Leitos");

            migrationBuilder.AddColumn<int>(
                name: "LeitoID",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Medicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Leitos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Funcionarios",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Especialidades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "DepartamentosFuncionarios",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_LeitoID",
                table: "Pacientes",
                column: "LeitoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Leitos_LeitoID",
                table: "Pacientes",
                column: "LeitoID",
                principalTable: "Leitos",
                principalColumn: "LeitoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Leitos_LeitoID",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_LeitoID",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "LeitoID",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Especialidades");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Leitos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "PacienteID",
                table: "Leitos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "DepartamentosFuncionarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_Leitos_PacienteID",
                table: "Leitos",
                column: "PacienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Leitos_Pacientes_PacienteID",
                table: "Leitos",
                column: "PacienteID",
                principalTable: "Pacientes",
                principalColumn: "PacienteID");
        }
    }
}
