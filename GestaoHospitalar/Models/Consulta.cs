using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Consulta
    {
        [Key]
        public int ConsultaID { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
        public DateTime DataHora { get; set; }
        public string Motivo { get; set; }
        public string Observacoes { get; set; }
        public string Status { get; set; }
        public string Diagnostico { get; set; }
        public string TratamentoRecomendado { get; set; }

        // Relacionamentos
        [ForeignKey("PacienteID")]
        public Paciente Paciente { get; set; }
        [ForeignKey("MedicoID")]

        public Medico Medico { get; set; }
    }
}
