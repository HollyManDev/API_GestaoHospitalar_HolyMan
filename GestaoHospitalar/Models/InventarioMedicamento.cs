// InventarioMedicamento.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHospitalar.Models
{
    public class InventarioMedicamento
    {
        [Key]
        public int MedicamentoID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }
        public int FornecedorID { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        [ForeignKey("FornecedorID")]
        public Fornecedor Fornecedor { get; set; }

        public ICollection<FacturaMedicamento> FaturasMedicamentos { get; set; }
    }
}
