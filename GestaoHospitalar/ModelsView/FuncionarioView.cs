namespace GestaoHospitalar.ModelsView
{
    public class FuncionarioView
    {
        public int FuncionarioID { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public List<string> Telefones { get; set; } = new List<string>();  // Lista de telefones como strings
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public Boolean Status { get; set; }
        public int DepartamentoID { get; set; }
        public int CargoID { get; set; }
    }
}
