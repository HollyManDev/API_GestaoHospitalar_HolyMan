using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoHospitalar.Migrations
{
    /// <inheritdoc />
    public partial class Creating_DataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartamentosFuncionarios",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentosFuncionarios", x => x.DepartamentoID);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentosMedicos",
                columns: table => new
                {
                    EquipamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentosMedicos", x => x.EquipamentoID);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialidadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspecialidadeID);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorID);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoEmergenciaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoEmergenciaTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoEmergenciaRelacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoricoMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seguro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteID);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioID);
                    table.ForeignKey(
                        name: "FK_Funcionarios_DepartamentosFuncionarios_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "DepartamentosFuncionarios",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EspecialidadeID = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Certificacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoID);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_EspecialidadeID",
                        column: x => x.EspecialidadeID,
                        principalTable: "Especialidades",
                        principalColumn: "EspecialidadeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    ExameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preço = table.Column<double>(type: "float", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.ExameID);
                    table.ForeignKey(
                        name: "FK_Exames_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID");
                });

            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    FaturaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => x.FaturaID);
                    table.ForeignKey(
                        name: "FK_Faturas_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAtendimentos",
                columns: table => new
                {
                    HistoricoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAtendimentos", x => x.HistoricoID);
                    table.ForeignKey(
                        name: "FK_HistoricoAtendimentos_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventarioMedicamentos",
                columns: table => new
                {
                    MedicamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FornecedorID = table.Column<int>(type: "int", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioMedicamentos", x => x.MedicamentoID);
                    table.ForeignKey(
                        name: "FK_InventarioMedicamentos_Fornecedores_FornecedorID",
                        column: x => x.FornecedorID,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioMedicamentos_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID");
                });

            migrationBuilder.CreateTable(
                name: "Leitos",
                columns: table => new
                {
                    LeitoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLeito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitos", x => x.LeitoID);
                    table.ForeignKey(
                        name: "FK_Leitos_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID");
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    AgendamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    MedicoID = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoAgendamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoID);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "MedicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ConsultaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    MedicoID = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TratamentoRecomendado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.ConsultaID);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "MedicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoVisitas",
                columns: table => new
                {
                    VisitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    MedicoID = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoVisita = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoVisitas", x => x.VisitaID);
                    table.ForeignKey(
                        name: "FK_HistoricoVisitas_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "MedicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoVisitas_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultadosExames",
                columns: table => new
                {
                    ResultadoExameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExameID = table.Column<int>(type: "int", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValoresReferencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterpretacaoMedica = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadosExames", x => x.ResultadoExameID);
                    table.ForeignKey(
                        name: "FK_ResultadosExames_Exames_ExameID",
                        column: x => x.ExameID,
                        principalTable: "Exames",
                        principalColumn: "ExameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultadosExames_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    ReciboID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaID = table.Column<int>(type: "int", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    MetodoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.ReciboID);
                    table.ForeignKey(
                        name: "FK_Recibos_Faturas_FaturaID",
                        column: x => x.FaturaID,
                        principalTable: "Faturas",
                        principalColumn: "FaturaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescricoes",
                columns: table => new
                {
                    PrescricaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaID = table.Column<int>(type: "int", nullable: false),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstrucoesUso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPrescricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescricoes", x => x.PrescricaoID);
                    table.ForeignKey(
                        name: "FK_Prescricoes_Consultas_ConsultaID",
                        column: x => x.ConsultaID,
                        principalTable: "Consultas",
                        principalColumn: "ConsultaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescricoes_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_MedicoID",
                table: "Agendamentos",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_PacienteID",
                table: "Agendamentos",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoID",
                table: "Consultas",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteID",
                table: "Consultas",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteID",
                table: "Exames",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Faturas_PacienteID",
                table: "Faturas",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoID",
                table: "Funcionarios",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAtendimentos_PacienteID",
                table: "HistoricoAtendimentos",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoVisitas_MedicoID",
                table: "HistoricoVisitas",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoVisitas_PacienteID",
                table: "HistoricoVisitas",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioMedicamentos_FornecedorID",
                table: "InventarioMedicamentos",
                column: "FornecedorID");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioMedicamentos_PacienteID",
                table: "InventarioMedicamentos",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Leitos_PacienteID",
                table: "Leitos",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeID",
                table: "Medicos",
                column: "EspecialidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescricoes_ConsultaID",
                table: "Prescricoes",
                column: "ConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescricoes_PacienteID",
                table: "Prescricoes",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_FaturaID",
                table: "Recibos",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosExames_ExameID",
                table: "ResultadosExames",
                column: "ExameID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosExames_PacienteID",
                table: "ResultadosExames",
                column: "PacienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "EquipamentosMedicos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "HistoricoAtendimentos");

            migrationBuilder.DropTable(
                name: "HistoricoVisitas");

            migrationBuilder.DropTable(
                name: "InventarioMedicamentos");

            migrationBuilder.DropTable(
                name: "Leitos");

            migrationBuilder.DropTable(
                name: "Prescricoes");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "ResultadosExames");

            migrationBuilder.DropTable(
                name: "DepartamentosFuncionarios");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Faturas");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
