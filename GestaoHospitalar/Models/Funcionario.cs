using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHospitalar.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioID { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public string Departamento { get; set; }
        public Boolean Status { get; set; }
       

        [ForeignKey("DepartamentoID")]
        public DepartamentosFuncionarios departamentoFuncionario { get; set; }
      
    }
}
