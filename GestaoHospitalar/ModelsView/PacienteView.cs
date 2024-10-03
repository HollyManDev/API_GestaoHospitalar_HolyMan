namespace GestaoHospitalar.ModelsView
{
    public class PacienteView
    {
        public int PacienteID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string BI { get; set; }
        public string ContatoEmergenciaNome { get; set; }
        public string ContatoEmergenciaTelefone { get; set; }
        public string ContatoEmergenciaRelacao { get; set; }
        public string HistoricoMedico { get; set; }
        public string? Seguro { get; set; }
        public Boolean Status { get; set; }
        public int? Leito { get; set; }

    }
}
