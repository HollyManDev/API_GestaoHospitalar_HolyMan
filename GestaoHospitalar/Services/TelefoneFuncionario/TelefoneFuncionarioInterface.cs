using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.TelefoneFuncionarioServices
{
    public interface TelefoneFuncionarioInterface
    {
        Task<ServiceResponse<List<TelefoneFuncionario>>> GetTelefonesFuncionarios();
        Task<ServiceResponse<TelefoneFuncionario>> FindTelefoneFuncionario(int id);
        Task<ServiceResponse<List<TelefoneFuncionario>>> CreateTelefoneFuncionario(TelefoneFuncionarioView newTelefoneFuncionarioView);
        Task<ServiceResponse<List<TelefoneFuncionario>>> UpdateTelefoneFuncionario(TelefoneFuncionarioView updatedTelefoneFuncionarioView);
        Task<ServiceResponse<List<TelefoneFuncionario>>> DeleteTelefoneFuncionario(int id);
    }
}
