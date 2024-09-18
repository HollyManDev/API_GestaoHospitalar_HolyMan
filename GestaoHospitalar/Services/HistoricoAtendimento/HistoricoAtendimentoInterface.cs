using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.HistoricoAtendimentoServices
{
    public interface HistoricoAtendimentoInterface
    {
        Task<ServiceResponse<List<HistoricoAtendimento>>> GetHistoricosAtendimento();
        Task<ServiceResponse<HistoricoAtendimento>> FindHistoricoAtendimento(int id);
        Task<ServiceResponse<List<HistoricoAtendimento>>> CreateHistoricoAtendimento(HistoricoAtendimentoView newHistoricoAtendimento);
        Task<ServiceResponse<List<HistoricoAtendimento>>> UpdateHistoricoAtendimento(HistoricoAtendimentoView updateHistoricoAtendimento);
        Task<ServiceResponse<List<HistoricoAtendimento>>> InactivateHistoricoAtendimento(int id);
        Task<ServiceResponse<List<HistoricoAtendimento>>> ActivateHistoricoAtendimento(int id);
    }
}
