using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Exame
    {
        [Key]
        public int ExameID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Preço { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        public ICollection<ResultadoExame> ResultadosExames { get; set; }
    }
}
