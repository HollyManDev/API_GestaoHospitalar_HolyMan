using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHospitalar.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioID { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public Boolean Status { get; set; }
        public int DepartamentoID { get; set; }
        public int CargoID { get; set; }

        // Relacionamento com telefones
        public List<TelefoneFuncionario> Telefones { get; set; } = new List<TelefoneFuncionario>();

        // Relacionamentos com outras entidades
        [ForeignKey("DepartamentoID")]
        public DepartamentosFuncionarios departamentoFuncionario { get; set; }

        [ForeignKey("CargoID")]
        public Cargo cargo { get; set; }
    }
}
