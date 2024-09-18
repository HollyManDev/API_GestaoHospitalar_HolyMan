using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;

namespace GestaoHospitalar.Services.PacienteServices
{
    public interface PacienteInterface
    {
        Task<ServiceResponse<List<Paciente>>> GetPacientes();
        Task<ServiceResponse<Paciente>> FindPaciente(int id);
        Task<ServiceResponse<List<Paciente>>> CreatePaciente(PacienteView newPaciente);
        Task<ServiceResponse<List<Paciente>>> UpdatePaciente(PacienteView updatePaciente);
        Task<ServiceResponse<List<Paciente>>> InactivatePaciente(int id);
        Task<ServiceResponse<List<Paciente>>> ActivatePaciente(int id);
    }
}
