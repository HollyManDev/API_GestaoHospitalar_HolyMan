using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class HistoricoVisita
    {
        [Key]
        public int VisitaID { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
        public DateTime DataHora { get; set; }
        public string TipoVisita { get; set; }

        // Relacionamentos
        [ForeignKey("PacienteID")]
        public Paciente Paciente { get; set; }
        [ForeignKey("MedicoID")]

        public Medico Medico { get; set; }
    }
}
