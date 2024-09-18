using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Agendamento
    {
        [Key]
        public int AgendamentoID { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
        public DateTime DataHora { get; set; }
        public string TipoAgendamento { get; set; }
        public string Status { get; set; } // Responsavel em saber se e pendente, atendido 
        public string Observacoes { get; set; }
        public Boolean StatusExist { get; set; } //Responsavel por estar activo ou nao

        // Relacionamentos
        [ForeignKey("PacienteID")]
        public Paciente Paciente { get; set; }
        [ForeignKey("MedicoID")]
        public Medico Medico { get; set; }
    }
}
