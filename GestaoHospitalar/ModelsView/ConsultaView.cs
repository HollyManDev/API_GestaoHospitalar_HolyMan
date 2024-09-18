namespace GestaoHospitalar.ModelsView
{
    public class ConsultaView
    {
        public int ConsultaID { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
        public DateTime DataHora { get; set; }
        public string Motivo { get; set; }
        public string Observacoes { get; set; }
        public string Status { get; set; }
        public string Diagnostico { get; set; }
        public string TratamentoRecomendado { get; set; }
    }
}
