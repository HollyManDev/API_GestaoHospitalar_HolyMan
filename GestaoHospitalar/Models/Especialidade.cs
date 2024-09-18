using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Especialidade
    {
        [Key]
        public int EspecialidadeID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        public ICollection<Medico> Medicos { get; set; }
    }
}
