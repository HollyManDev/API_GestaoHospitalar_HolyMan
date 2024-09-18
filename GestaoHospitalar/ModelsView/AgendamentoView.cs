namespace GestaoHospitalar.ModelsView
{
    public class AgendamentoView
    {
        public int AgendamentoID { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
        public DateTime DataHora { get; set; }
        public string TipoAgendamento { get; set; }
        public string Status { get; set; }
        public string Observacoes { get; set; }
        public Boolean StatusExist { get; set; }


    }
}
