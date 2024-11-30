using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;

namespace GestaoHospitalar.Services
{
    public interface CargoInterface
    {
        Task<ServiceResponse<List<Cargo>>> GetCargos();
        Task<ServiceResponse<Cargo>> FindCargo(int id);
        Task<ServiceResponse<List<Cargo>>> CreateCargo(CargoView newLeito);
        Task<ServiceResponse<List<Cargo>>> UpdateCargo(CargoView updateLeito);
        Task<ServiceResponse<List<Cargo>>> DeleteCargo(int id);
    }
}
