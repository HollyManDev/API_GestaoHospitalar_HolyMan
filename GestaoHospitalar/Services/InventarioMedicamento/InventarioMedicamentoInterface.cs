using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.InventarioMedicamentoServices
{
    public interface InventarioMedicamentoInterface
    {
        Task<ServiceResponse<List<InventarioMedicamento>>> GetInventarioMedicamentos();
        Task<ServiceResponse<InventarioMedicamento>> FindInventarioMedicamento(int id);
        Task<ServiceResponse<List<InventarioMedicamento>>> CreateInventarioMedicamento(InventarioMedicamentoView newInventarioMedicamento);
        Task<ServiceResponse<List<InventarioMedicamento>>> UpdateInventarioMedicamento(InventarioMedicamentoView updateInventarioMedicamento);
        Task<ServiceResponse<List<InventarioMedicamento>>> InactivateInventarioMedicamento(int id);
        Task<ServiceResponse<List<InventarioMedicamento>>> ActivateInventarioMedicamento(int id);
    }
}
