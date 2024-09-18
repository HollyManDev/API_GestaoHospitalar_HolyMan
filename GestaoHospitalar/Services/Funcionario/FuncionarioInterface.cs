using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.FuncionarioServices
{
    public interface FuncionarioInterface
    {
        Task<ServiceResponse<List<Funcionario>>> GetFuncionarios();
        Task<ServiceResponse<Funcionario>> FindFuncionario(int id);
        Task<ServiceResponse<List<Funcionario>>> CreateFuncionario(FuncionarioView newFuncionario);
        Task<ServiceResponse<List<Funcionario>>> UpdateFuncionario(FuncionarioView updateFuncionario);
        Task<ServiceResponse<List<Funcionario>>> InactivateFuncionario(int id);
        Task<ServiceResponse<List<Funcionario>>> ActivateFuncionario(int id);
    }
}
