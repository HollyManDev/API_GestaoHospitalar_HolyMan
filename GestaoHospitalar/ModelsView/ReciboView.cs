namespace GestaoHospitalar.ModelsView
{
    public class ReciboView
    {
        public int ReciboID { get; set; }
        public int FaturaID { get; set; }
        public DateTime DataRecebimento { get; set; }
        public double Valor { get; set; }
        public string MetodoPagamento { get; set; }
        public Boolean Status { get; set; }
    }
}
