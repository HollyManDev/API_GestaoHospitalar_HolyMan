using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.MedicoServices
{
    public interface MedicoInterface
    {
        Task<ServiceResponse<List<Medico>>> GetMedicos();
        Task<ServiceResponse<Medico>> FindMedico(int id);
        Task<ServiceResponse<List<Medico>>> CreateMedico(MedicoView newMedico);
        Task<ServiceResponse<List<Medico>>> UpdateMedico(MedicoView updateMedico);
        Task<ServiceResponse<List<Medico>>> DeleteMedico(int id);
    }
}
