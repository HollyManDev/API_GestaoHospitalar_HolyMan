using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Recibo
    {
        [Key]
        public int ReciboID { get; set; }
        public int FaturaID { get; set; }
        public DateTime DataRecebimento { get; set; }
        public double Valor { get; set; }
        public string MetodoPagamento { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        [ForeignKey("FaturaID")]
        public Factura Factura { get; set; }
    }
}
