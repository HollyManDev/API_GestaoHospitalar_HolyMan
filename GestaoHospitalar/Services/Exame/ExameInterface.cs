using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ExameServices
{
    public interface ExameInterface
    {
        Task<ServiceResponse<List<Exame>>> GetExames();
        Task<ServiceResponse<Exame>> FindExame(int id);
        Task<ServiceResponse<List<Exame>>> CreateExame(ExameView newExame);
        Task<ServiceResponse<List<Exame>>> UpdateExame(ExameView updateExame);
        Task<ServiceResponse<List<Exame>>> InactivateExame(int id);
        Task<ServiceResponse<List<Exame>>> ActivateExame(int id);
    }
}
