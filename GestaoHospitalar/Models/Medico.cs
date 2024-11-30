using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoHospitalar.Models
{
    public class Medico
    {
        [Key]
        public int MedicoID { get; set; }
        public string Nome { get; set; }
        public int EspecialidadeID { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Endereco { get; set; }
        public string HorarioTrabalho { get; set; }
        public Boolean Status { get; set; }

        // Relacionamentos
        [ForeignKey("EspecialidadeID")]
        public Especialidade Especialidade { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
        public ICollection<HistoricoVisita> HistoricoVisitas { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }


    }
}
