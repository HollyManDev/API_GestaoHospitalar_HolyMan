using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace GestaoHospitalar.Models
{
    public class Paciente
    {
        [Key]
        public int PacienteID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string BI { get; set; }
        public string Fotografia { get; set; }
        public string ContatoEmergenciaNome { get; set; }
        public string ContatoEmergenciaTelefone { get; set; }
        public string ContatoEmergenciaRelacao { get; set; }
        public string HistoricoMedico { get; set; }
        public string? Seguro { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        public int? LeitoID { get; set; }

        // Relacionamentos
        [ForeignKey("LeitoID")]
        public Leito Leito { get; set; }

        public ICollection<Consulta> Consultas { get; set; }
        public ICollection<Exame> Exames { get; set; }
        public ICollection<Prescricao> Prescricoes { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }

        public ICollection<HistoricoAtendimento> HistoricoAtendimentos { get; set; }
        public ICollection<InventarioMedicamento> InventarioMedicamentos { get; set; }
        public ICollection<HistoricoVisita> HistoricoVisitas { get; set; }
    }
}
