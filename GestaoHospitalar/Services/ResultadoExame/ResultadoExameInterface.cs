using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ResultadoExameServices
{
    public interface ResultadoExameInterface
    {
        Task<ServiceResponse<List<ResultadoExame>>> GetResultadosExames();
        Task<ServiceResponse<ResultadoExame>> FindResultadoExame(int id);
        Task<ServiceResponse<List<ResultadoExame>>> CreateResultadoExame(ResultadoExameView newResultadoExame);
        Task<ServiceResponse<List<ResultadoExame>>> UpdateResultadoExame(ResultadoExameView updateResultadoExame);
        Task<ServiceResponse<List<ResultadoExame>>> InactivateResultadoExame(int id);
        Task<ServiceResponse<List<ResultadoExame>>> ActivateResultadoExame(int id);
    }
}
