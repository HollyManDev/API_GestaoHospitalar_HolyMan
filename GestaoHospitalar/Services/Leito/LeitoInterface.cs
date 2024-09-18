using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.LeitoServices
{
    public interface LeitoInterface
    {
        Task<ServiceResponse<List<Leito>>> GetLeitos();
        Task<ServiceResponse<Leito>> FindLeito(int id);
        Task<ServiceResponse<List<Leito>>> CreateLeito(LeitoView newLeito);
        Task<ServiceResponse<List<Leito>>> UpdateLeito(LeitoView updateLeito);
        Task<ServiceResponse<List<Leito>>> DeleteLeito(int id);
    }
}
