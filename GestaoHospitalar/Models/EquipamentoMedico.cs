using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class EquipamentoMedico
    {
        [Key]
        public int EquipamentoID { get; set; }
        public string Nome { get; set; }
        public DateTime DataAquisicao { get; set; }
        public Boolean Status { get; set; }
        public string Localizacao { get; set; }
       
    }
}
