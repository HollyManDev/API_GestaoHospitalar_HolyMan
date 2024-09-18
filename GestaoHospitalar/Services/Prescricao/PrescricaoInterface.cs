using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.PrescricaoServices
{
    public interface PrescricaoInterface
    {
        Task<ServiceResponse<List<Prescricao>>> GetPrescricoes();
        Task<ServiceResponse<Prescricao>> FindPrescricao(int id);
        Task<ServiceResponse<List<Prescricao>>> CreatePrescricao(PrecricaoView newPrescricao);
        Task<ServiceResponse<List<Prescricao>>> UpdatePrescricao(PrecricaoView updatePrescricao);
        Task<ServiceResponse<List<Prescricao>>> InactivatePrescricao(int id);
        Task<ServiceResponse<List<Prescricao>>> ActivatePrescricao(int id);
    }
}
