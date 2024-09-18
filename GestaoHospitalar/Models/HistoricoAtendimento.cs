using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class HistoricoAtendimento
    {
        [Key]
        public int HistoricoID { get; set; }
        public int PacienteID { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        [ForeignKey("PacienteID")]
        public Paciente Paciente { get; set; }
    }
}
