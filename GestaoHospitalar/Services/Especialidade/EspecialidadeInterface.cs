using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.EspecialidadeServices
{
    public interface EspecialidadeInterface
    {
        Task<ServiceResponse<List<Especialidade>>> GetEspecialidades();
        Task<ServiceResponse<Especialidade>> FindEspecialidade(int id);
        Task<ServiceResponse<List<Especialidade>>> CreateEspecialidade(EspecialidadeView newEspecialidade);
        Task<ServiceResponse<List<Especialidade>>> UpdateEspecialidade(EspecialidadeView updateEspecialidade);
        Task<ServiceResponse<List<Especialidade>>> DeleteEspecialidade(int id);
    }
}
