// Factura.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHospitalar.Models
{
    public class Factura
    {
        [Key]
        public int FaturaID { get; set; }
        public int PacienteID { get; set; }
        public double Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; }
        public Boolean StatusExist { get; set; }
        public string FormaPagamento { get; set; }

        // Relacionamentos
        [ForeignKey("PacienteID")]
        public Paciente Paciente { get; set; }

        public ICollection<FacturaMedicamento> FaturasMedicamentos { get; set; }
    }
}
