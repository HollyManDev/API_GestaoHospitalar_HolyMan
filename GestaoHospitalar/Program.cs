
using GestaoHospitalar.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using GestaoHospitalar.Services.PacienteServices;
using GestaoHospitalar.Services.DepartamentoServices;
using GestaoHospitalar.Services.FuncionarioServices;
using GestaoHospitalar.Services.LeitoServices;
using GestaoHospitalar.Services.EspecialidadeServices;
using GestaoHospitalar.Services.MedicoServices;
using GestaoHospitalar.Services.AgendamentoServices;
using GestaoHospitalar.Services.ConsultaServices;
using GestaoHospitalar.Services.EquipamentoMedicoServices;
using GestaoHospitalar.Services.ExameServices;
using GestaoHospitalar.Services.FacturaMedicamentoServices;
using GestaoHospitalar.Services.FacturaServices;
using GestaoHospitalar.Services.FornecedorServices;
using GestaoHospitalar.Services.HistoricoAtendimentoServices;
using GestaoHospitalar.Services.InventarioMedicamentoServices;
using GestaoHospitalar.Services.PrescricaoServices;
using GestaoHospitalar.Services.ReciboServices;
using GestaoHospitalar.Services.ResultadoExameServices;
using GestaoHospitalar.Services.CamaServices;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // Ignorar ciclos de referências
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PacienteInterface, PacienteService>();
builder.Services.AddScoped<DepartamentoInterface, DepartamentoService>();
builder.Services.AddScoped<FuncionarioInterface, FuncionarioService>();
builder.Services.AddScoped<LeitoInterface, LeitoService>();
builder.Services.AddScoped<CamaInterface,CamaService>();
builder.Services.AddScoped<MedicoInterface, MedicoService>();
builder.Services.AddScoped<EspecialidadeInterface, EspecialidadeService>();
builder.Services.AddScoped<ConsultaInterface, ConsultaService>();
builder.Services.AddScoped<ExameInterface, ExameService>();
builder.Services.AddScoped<ResultadoExameInterface, ResultadoExameService>();
builder.Services.AddScoped<PrescricaoInterface, PrescricaoService>();
builder.Services.AddScoped<AgendamentoInterface, AgendamentoService>();
builder.Services.AddScoped<FacturaInterface, FacturaService>();
builder.Services.AddScoped<ReciboInterface, ReciboService>();
builder.Services.AddScoped<FacturaMedicamentoInterface, FacturaMedicamentoService>();
builder.Services.AddScoped<HistoricoAtendimentoInterface, HistoricoAtendimentoService>();
builder.Services.AddScoped<InventarioMedicamentoInterface, InventarioMedicamentoService>();
builder.Services.AddScoped<FornecedorInterface, FornecedorService>();
builder.Services.AddScoped<EquipamentoMedicoInterface, EquipamentoMedicoService>();
builder.Services.AddScoped<LeitoInterface, LeitoService>();
//builder.Services.AddScoped<HistoricoVisitaInterface, HistoricoVisitaService>();

// Configuração do DbContext para o Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar o middleware de CORS
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
