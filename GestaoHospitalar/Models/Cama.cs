using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHospitalar.Models
{
    public class Cama
    {
        [Key]
        public int CamaID { get; set; }
        public int? LeitoID { get; set; }
        public string Descricao { get; set; }
        public Boolean Status { get; set; }
        [ForeignKey("LeitoID")]
        public Leito Leito { get; set; }
    }
}
