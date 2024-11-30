using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GestaoHospitalar.Models
{
    public class Cargo
    {
        [Key]
        public int CargoID { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
