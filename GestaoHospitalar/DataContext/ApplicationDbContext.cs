using GestaoHospitalar.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoHospitalar.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cama> Camas { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<ResultadoExame> ResultadosExames { get; set; }
        public DbSet<Prescricao> Prescricoes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Factura> Faturas { get; set; }  
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<FacturaMedicamento> FacturasMedicamentos { get; set; }
        public DbSet<HistoricoAtendimento> HistoricoAtendimentos { get; set; }
        public DbSet<InventarioMedicamento> InventarioMedicamentos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<EquipamentoMedico> EquipamentosMedicos { get; set; }
        public DbSet<Leito> Leitos { get; set; }
      
        public DbSet<HistoricoVisita> HistoricoVisitas { get; set; }
        public DbSet<DepartamentosFuncionarios> DepartamentosFuncionarios { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configurações para Paciente
        //    modelBuilder.Entity<Paciente>()
        //        .HasKey(p => p.PacienteID);

        //    modelBuilder.Entity<Paciente>()
        //        .HasMany(p => p.Consultas)
        //        .WithOne(c => c.Paciente)
        //        .HasForeignKey(c => c.PacienteID);

        //    modelBuilder.Entity<Paciente>()
        //        .HasMany(p => p.Exames)
        //        .WithOne(e => e.Paciente)
        //        .HasForeignKey(e => e.PacienteID);

        //    modelBuilder.Entity<Paciente>()
        //        .HasMany(p => p.Agendamentos)
        //        .WithOne(a => a.Paciente)
        //        .HasForeignKey(a => a.PacienteID);

        //    modelBuilder.Entity<Paciente>()
        //        .HasMany(p => p.HistoricoAtendimentos)
        //        .WithOne(h => h.Paciente)
        //        .HasForeignKey(h => h.PacienteID);

        //    modelBuilder.Entity<Paciente>()
        //        .HasMany(p => p.Leitos)
        //        .WithOne(l => l.Paciente)
        //        .HasForeignKey(l => l.PacienteID)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    // Configurações para Medico
        //    modelBuilder.Entity<Medico>()
        //        .HasKey(m => m.MedicoID);

        //    modelBuilder.Entity<Medico>()
        //        .HasOne(m => m.EspecialidadeView)
        //        .WithMany(e => e.Medicos)
        //        .HasForeignKey(m => m.EspecialidadeID);

        //    modelBuilder.Entity<Medico>()
        //        .HasMany(m => m.Consultas)
        //        .WithOne(c => c.Medico)
        //        .HasForeignKey(c => c.MedicoID);

        //    modelBuilder.Entity<Medico>()
        //        .HasMany(m => m.HistoricoVisitas)
        //        .WithOne(h => h.Medico)
        //        .HasForeignKey(h => h.MedicoID);

        //    modelBuilder.Entity<Medico>()
        //        .HasMany(m => m.Agendamentos)
        //        .WithOne(a => a.Medico)
        //        .HasForeignKey(a => a.MedicoID);

        //    // Configurações para EspecialidadeView
        //    modelBuilder.Entity<EspecialidadeView>()
        //        .HasKey(e => e.EspecialidadeID);

        //    modelBuilder.Entity<EspecialidadeView>()
        //        .HasMany(e => e.Medicos)
        //        .WithOne(m => m.EspecialidadeView)
        //        .HasForeignKey(m => m.EspecialidadeID);

        //    // Configurações para Consulta
        //    modelBuilder.Entity<Consulta>()
        //        .HasKey(c => c.ConsultaID);

        //    modelBuilder.Entity<Consulta>()
        //        .HasOne(c => c.Paciente)
        //        .WithMany(p => p.Consultas)
        //        .HasForeignKey(c => c.PacienteID);

        //    modelBuilder.Entity<Consulta>()
        //        .HasOne(c => c.Medico)
        //        .WithMany(m => m.Consultas)
        //        .HasForeignKey(c => c.MedicoID);

        //    modelBuilder.Entity<Consulta>()
        //        .HasMany(c => c.Prescricoes)
        //        .WithOne(p => p.Consulta)
        //        .HasForeignKey(p => p.ConsultaID);

        //    // Configurações para Exame
        //    modelBuilder.Entity<Exame>()
        //        .HasKey(e => e.ExameID);

        //    modelBuilder.Entity<Exame>()
        //        .HasMany(e => e.ResultadosExames)
        //        .WithOne(r => r.Exame)
        //        .HasForeignKey(r => r.ExameID);

        //    // Configurações para ResultadoExame
        //    modelBuilder.Entity<ResultadoExame>()
        //        .HasKey(r => r.ResultadoExameID);

        //    modelBuilder.Entity<ResultadoExame>()
        //        .HasOne(r => r.Paciente)
        //        .WithMany(p => p.Exames)
        //        .HasForeignKey(r => r.PacienteID);

        //    // Configurações para Prescricao
        //    modelBuilder.Entity<Prescricao>()
        //        .HasKey(p => p.PrescricaoID);

        //    modelBuilder.Entity<Prescricao>()
        //        .HasOne(p => p.Consulta)
        //        .WithMany(c => c.Prescricoes)
        //        .HasForeignKey(p => p.ConsultaID);

        //    // Configurações para InventarioMedicamento
        //    modelBuilder.Entity<InventarioMedicamento>()
        //        .HasKey(i => i.MedicamentoID);

        //    modelBuilder.Entity<InventarioMedicamento>()
        //        .HasOne(i => i.Fornecedor)
        //        .WithMany(f => f.InventarioMedicamentos)
        //        .HasForeignKey(i => i.FornecedorID);

        //    // Configurações para Fornecedor
        //    modelBuilder.Entity<Fornecedor>()
        //        .HasKey(f => f.FornecedorID);

        //    // Configurações para Leito
        //    modelBuilder.Entity<Leito>()
        //        .HasKey(l => l.LeitoID);

        //    modelBuilder.Entity<Leito>()
        //        .HasOne(l => l.Paciente)
        //        .WithMany(p => p.Leitos)
        //        .HasForeignKey(l => l.PacienteID)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    // Configurações para HistoricoVisita
        //    modelBuilder.Entity<HistoricoVisita>()
        //        .HasKey(h => h.VisitaID);

        //    modelBuilder.Entity<HistoricoVisita>()
        //        .HasOne(h => h.Paciente)
        //        .WithMany(p => p.HistoricoVisitas)
        //        .HasForeignKey(h => h.PacienteID);

        //    modelBuilder.Entity<HistoricoVisita>()
        //        .HasOne(h => h.Medico)
        //        .WithMany(m => m.HistoricoVisitas)
        //        .HasForeignKey(h => h.MedicoID);

        //    // Configurações para DepartamentosFuncionario
        //    modelBuilder.Entity<DepartamentosFuncionarios>()
        //        .HasKey(d => d.DepartamentoID);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
