using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class mmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContatoEmergenciaNome",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ContatoEmergenciaRelacao",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ContatoEmergenciaTelefone",
                table: "Pacientes");

            migrationBuilder.AlterColumn<string>(
                name: "Seguro",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContatoEmergencia",
                columns: table => new
                {
                    ContatoEmergenciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContatoEmergenciaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoEmergenciaTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoEmergenciaRelacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoEmergencia", x => x.ContatoEmergenciaID);
                    table.ForeignKey(
                        name: "FK_ContatoEmergencia_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContatoEmergencia_PacienteID",
                table: "ContatoEmergencia",
                column: "PacienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatoEmergencia");

            migrationBuilder.AlterColumn<string>(
                name: "Seguro",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContatoEmergenciaNome",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContatoEmergenciaRelacao",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContatoEmergenciaTelefone",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
