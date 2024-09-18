namespace GestaoHospitalar.ModelsView
{
    public class ResultadoExameView
    {
        public int ResultadoExameID { get; set; }
        public int ExameID { get; set; }
        public int PacienteID { get; set; }
        public DateTime Data { get; set; }
        public string Resultado { get; set; }
        public string Observacoes { get; set; }
        public string ValoresReferencia { get; set; }
        public string InterpretacaoMedica { get; set; }
        public Boolean Status { get; set; }
    }
}
