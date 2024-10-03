using System;

namespace GestaoHospitalar.ModelsView
{
    public class EquipamentoMedicoView
    {
        public int EquipamentoID { get; set; }
        public string Nome { get; set; }
        public DateTime DataAquisicao { get; set; }
        public Boolean Status { get; set; }
        public string Localizacao { get; set; }
       
    }
}
