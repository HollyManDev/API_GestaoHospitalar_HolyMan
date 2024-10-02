using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Fornecedor
    {
        [Key]
        public int FornecedorID { get; set; }
        public string Nome { get; set; }
        public string Nuit { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        public ICollection<InventarioMedicamento> InventarioMedicamentos { get; set; }
    }
}
