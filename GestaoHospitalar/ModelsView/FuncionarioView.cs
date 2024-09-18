namespace GestaoHospitalar.ModelsView
{
    public class FuncionarioView
    {
        public int FuncionarioID { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public string Departamento { get; set; }
        public Boolean Status { get; set; }
        public int DepartamentoFuncionario { get; set; }
    }
}
