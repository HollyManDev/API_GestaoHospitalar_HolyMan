namespace GestaoHospitalar.ModelsView
{
    public class HistoricoAtendimentoView
    {
        public int HistoricoID { get; set; }
        public int PacienteID { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public Boolean Status { get; set; }

    }
}
