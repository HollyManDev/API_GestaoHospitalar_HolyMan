namespace GestaoHospitalar.ModelsView
{
    public class TelefoneFuncionarioView
    {
        public int TelefoneID { get; set; } // ID único para o telefone
        public string Telefone { get; set; } // Número de telefone
        public int FuncionarioID { get; set; } // Chave estrangeira para o funcionário
    }
}
