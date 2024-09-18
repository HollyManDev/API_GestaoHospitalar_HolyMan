namespace GestaoHospitalar.ModelsView
{
    public class FacturaView
    {
        public int FaturaID { get; set; }
        public int PacienteID { get; set; }
        public double Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; } //Vou reutilizar para outros metodos
        public Boolean StatusExist { get; set; } //vou usar para Inactivate e Activate
        public string FormaPagamento { get; set; }
    }
}
