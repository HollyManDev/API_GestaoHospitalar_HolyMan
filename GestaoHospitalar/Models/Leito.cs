using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Leito
    {
        [Key]
        public int LeitoID { get; set; }
        public string Descricao { get; set; }
        public Boolean Status { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }

    }
}
