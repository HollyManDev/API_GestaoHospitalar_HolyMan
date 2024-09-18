using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.EquipamentoMedicoServices
{
    public interface EquipamentoMedicoInterface
    {
        Task<ServiceResponse<List<EquipamentoMedico>>> GetEquipamentosMedicos();
        Task<ServiceResponse<EquipamentoMedico>> FindEquipamentoMedico(int id);
        Task<ServiceResponse<List<EquipamentoMedico>>> CreateEquipamentoMedico(EquipamentoMedicoView newEquipamentoMedico);
        Task<ServiceResponse<List<EquipamentoMedico>>> UpdateEquipamentoMedico(EquipamentoMedicoView updateEquipamentoMedico);
        Task<ServiceResponse<List<EquipamentoMedico>>> InactivateEquipamentoMedico(int id);
        Task<ServiceResponse<List<EquipamentoMedico>>> ActivateEquipamentoMedico(int id);
    }
}
