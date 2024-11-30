namespace GestaoHospitalar.ModelsView
{
    public class ContatoEmergenciaView
    {
        public int ContatoEmergenciaID { get; set; }  // ID único para cada contato de emergência
        public string ContatoEmergenciaNome { get; set; }
        public string ContatoEmergenciaTelefone { get; set; }
        public string ContatoEmergenciaRelacao { get; set; }

        // Relacionamento com o Paciente
        public int PacienteID { get; set; }
    }
}
