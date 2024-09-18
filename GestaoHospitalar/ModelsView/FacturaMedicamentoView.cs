using GestaoHospitalar.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHospitalar.ModelsView
{
    public class FacturaMedicamentoView
    {
        public int FacturaMedicamentoID { get; set; } // ID da tabela intermediária

        public int FaturaID { get; set; }
      
        public Factura Factura { get; set; }

        public int MedicamentoID { get; set; }

        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double PrecoTotal { get; set; }
        public Boolean status { get; set; }
    }
}
