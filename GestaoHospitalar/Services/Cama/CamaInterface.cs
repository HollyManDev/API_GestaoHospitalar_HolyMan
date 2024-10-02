using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.CamaServices
{
    public interface CamaInterface
    {
        Task<ServiceResponse<List<Cama>>> GetCamas();
        Task<ServiceResponse<Cama>> FindCama(int id);
        Task<ServiceResponse<List<Cama>>> CreateCama(CamaView newCama);
        Task<ServiceResponse<List<Cama>>> UpdateCama(CamaView updateCama);
        Task<ServiceResponse<List<Cama>>> DeleteCama(int id);
    }
}
