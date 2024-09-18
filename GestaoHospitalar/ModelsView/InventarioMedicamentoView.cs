namespace GestaoHospitalar.ModelsView
{
    public class InventarioMedicamentoView
    {
        public int MedicamentoID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }
        public int FornecedorID { get; set; }
    }
}
