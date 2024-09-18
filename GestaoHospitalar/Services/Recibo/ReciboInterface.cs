using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ReciboServices
{
    public interface ReciboInterface
    {
        Task<ServiceResponse<List<Recibo>>> GetRecibos();
        Task<ServiceResponse<Recibo>> FindRecibo(int id);
        Task<ServiceResponse<List<Recibo>>> CreateRecibo(ReciboView newRecibo);
        Task<ServiceResponse<List<Recibo>>> UpdateRecibo(ReciboView updateRecibo);
        Task<ServiceResponse<List<Recibo>>> InactivateRecibo(int id);
        Task<ServiceResponse<List<Recibo>>> ActivateRecibo(int id);
    }
}
