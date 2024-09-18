using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.DepartamentoServices
{
    public interface DepartamentoInterface
    {
        Task<ServiceResponse<List<DepartamentosFuncionarios>>> GetDepartamentos();
        Task<ServiceResponse<DepartamentosFuncionarios>> FindDepartamento(int id);
        Task<ServiceResponse<List<DepartamentosFuncionarios>>> CreateDepartamento(DepartamentoView newDepartamento);
        Task<ServiceResponse<List<DepartamentosFuncionarios>>> UpdateDepartamento(DepartamentoView updateDepartamento);
        Task<ServiceResponse<List<DepartamentosFuncionarios>>> InactivateDepartamento(int id);
        Task<ServiceResponse<List<DepartamentosFuncionarios>>> ActivateDepartamento(int id);
    }
}
