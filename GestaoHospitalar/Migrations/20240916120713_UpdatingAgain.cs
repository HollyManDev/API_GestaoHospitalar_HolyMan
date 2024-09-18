using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ResultadosExames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Recibos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Prescricoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PacienteID",
                table: "InventarioMedicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "HistoricoAtendimentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Fornecedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StatusExist",
                table: "Faturas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Exames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "EquipamentosMedicos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "EquipamentosMedicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FacturasMedicamentos",
                columns: table => new
                {
                    FacturaMedicamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaID = table.Column<int>(type: "int", nullable: false),
                    MedicamentoID = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<double>(type: "float", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasMedicamentos", x => x.FacturaMedicamentoID);
                    table.ForeignKey(
                        name: "FK_FacturasMedicamentos_Faturas_FaturaID",
                        column: x => x.FaturaID,
                        principalTable: "Faturas",
                        principalColumn: "FaturaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturasMedicamentos_InventarioMedicamentos_MedicamentoID",
                        column: x => x.MedicamentoID,
                        principalTable: "InventarioMedicamentos",
                        principalColumn: "MedicamentoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventarioMedicamentos_PacienteID",
                table: "InventarioMedicamentos",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasMedicamentos_FaturaID",
                table: "FacturasMedicamentos",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasMedicamentos_MedicamentoID",
                table: "FacturasMedicamentos",
                column: "MedicamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioMedicamentos_Pacientes_PacienteID",
                table: "InventarioMedicamentos",
                column: "PacienteID",
                principalTable: "Pacientes",
                principalColumn: "PacienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioMedicamentos_Pacientes_PacienteID",
                table: "InventarioMedicamentos");

            migrationBuilder.DropTable(
                name: "FacturasMedicamentos");

            migrationBuilder.DropIndex(
                name: "IX_InventarioMedicamentos_PacienteID",
                table: "InventarioMedicamentos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ResultadosExames");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Recibos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Prescricoes");

            migrationBuilder.DropColumn(
                name: "PacienteID",
                table: "InventarioMedicamentos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "HistoricoAtendimentos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "StatusExist",
                table: "Faturas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "EquipamentosMedicos");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "EquipamentosMedicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
