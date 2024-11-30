using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class novatabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Funcionarios");

            migrationBuilder.CreateTable(
                name: "TelefoneFuncionario",
                columns: table => new
                {
                    TelefoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneFuncionario", x => x.TelefoneID);
                    table.ForeignKey(
                        name: "FK_TelefoneFuncionario_Funcionarios_FuncionarioID",
                        column: x => x.FuncionarioID,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelefoneFuncionario_FuncionarioID",
                table: "TelefoneFuncionario",
                column: "FuncionarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelefoneFuncionario");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
