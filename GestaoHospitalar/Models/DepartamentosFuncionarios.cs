using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class DepartamentosFuncionarios
    {
        [Key]
        public int DepartamentoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Boolean Status { get; set; }
    }
}
