namespace GestaoHospitalar.ModelsView
{
    public class PrecricaoView
    {
        public int PrescricaoID { get; set; }
        public int ConsultaID { get; set; }
        public string Medicamento { get; set; }
        public string Dosagem { get; set; }
        public string Frequencia { get; set; }
        public string Duracao { get; set; }
        public string InstrucoesUso { get; set; }
        public DateTime DataPrescricao { get; set; }
        public Boolean Status{ get; set; }
    }
}
