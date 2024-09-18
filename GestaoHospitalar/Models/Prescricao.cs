using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Prescricao
    {
        [Key]
        public int PrescricaoID { get; set; }
        public int ConsultaID { get; set; }
        public string Medicamento { get; set; }
        public string Dosagem { get; set; }
        public string Frequencia { get; set; }
        public string Duracao { get; set; }
        public string InstrucoesUso { get; set; }
        public DateTime DataPrescricao { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        [ForeignKey("ConsultaID")]
        public Consulta Consulta { get; set; }
    }
}
