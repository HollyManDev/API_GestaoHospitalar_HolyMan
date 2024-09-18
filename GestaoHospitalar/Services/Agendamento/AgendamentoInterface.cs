using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.AgendamentoServices
{
    public interface AgendamentoInterface
    {
        Task<ServiceResponse<List<Agendamento>>> GetAgendamentos();
        Task<ServiceResponse<Agendamento>> FindAgendamento(int id);
        Task<ServiceResponse<List<Agendamento>>> CreateAgendamento(AgendamentoView newAgendamento);
        Task<ServiceResponse<List<Agendamento>>> UpdateAgendamento(AgendamentoView updateAgendamento);
        Task<ServiceResponse<List<Agendamento>>> InactivateAgendamento(int id);
        Task<ServiceResponse<List<Agendamento>>> ActivateAgendamento(int id);
    }
}
