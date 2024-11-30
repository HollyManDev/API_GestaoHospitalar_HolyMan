using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHospitalar.Models
{
    public class TelefoneFuncionario
    {
        [Key]
        public int TelefoneID { get; set; }
        public string Telefone { get; set; }

        // Relacionamento com Funcionario
        public int FuncionarioID { get; set; }
        [ForeignKey("FuncionarioID")]
        public Funcionario Funcionario { get; set; }
    }
}
