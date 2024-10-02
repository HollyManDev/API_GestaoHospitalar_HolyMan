namespace GestaoHospitalar.ModelsView
{
    public class MedicoView
    {
        public int MedicoID { get; set; }
        public string Nome { get; set; }
        public int EspecialidadeID { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string HorarioTrabalho { get; set; }
        public Boolean Status { get; set; }
       
    }
}
