using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class addCama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroLeito",
                table: "Leitos",
                newName: "Descricao");

            migrationBuilder.CreateTable(
                name: "Camas",
                columns: table => new
                {
                    CamaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeitoID = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camas", x => x.CamaID);
                    table.ForeignKey(
                        name: "FK_Camas_Leitos_LeitoID",
                        column: x => x.LeitoID,
                        principalTable: "Leitos",
                        principalColumn: "LeitoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camas_LeitoID",
                table: "Camas",
                column: "LeitoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camas");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Leitos",
                newName: "NumeroLeito");
        }
    }
}
