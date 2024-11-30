using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.OutroServices
{
    public interface OutroInterface
    {
        Task<ServiceResponse<List<Outro>>> GetOutros();
        Task<ServiceResponse<Outro>> FindOutro(int id);
        Task<ServiceResponse<List<Outro>>> CreateOutro(OutroView newOutro);
        Task<ServiceResponse<List<Outro>>> UpdateOutro(OutroView updateOutro);
        Task<ServiceResponse<List<Outro>>> DeleteOutro(int id);
    }
}
