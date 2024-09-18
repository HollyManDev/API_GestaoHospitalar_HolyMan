using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHospitalar.Models
{
    public class FacturaMedicamento
    {
        [Key]
        public int FacturaMedicamentoID { get; set; } // ID da tabela intermediária

        public int FaturaID { get; set; }
        [ForeignKey("FaturaID")]
        public Factura Factura { get; set; }

        public int MedicamentoID { get; set; }
        [ForeignKey("MedicamentoID")]
        public InventarioMedicamento Medicamento { get; set; }

        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double PrecoTotal { get; set; }
        public Boolean status { get; set; }
    }
}
