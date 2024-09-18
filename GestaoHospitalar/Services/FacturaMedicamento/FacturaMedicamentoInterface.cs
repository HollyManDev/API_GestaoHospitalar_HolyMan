using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.FacturaMedicamentoServices
{
    public interface FacturaMedicamentoInterface
    {
        Task<ServiceResponse<List<FacturaMedicamento>>> GetFacturasMedicamentos();
        Task<ServiceResponse<FacturaMedicamento>> FindFacturaMedicamento(int id);
        Task<ServiceResponse<List<FacturaMedicamento>>> CreateFacturaMedicamento(FacturaMedicamentoView newFacturaMedicamento);
        Task<ServiceResponse<List<FacturaMedicamento>>> UpdateFacturaMedicamento(FacturaMedicamentoView updateFacturaMedicamento);
        Task<ServiceResponse<List<FacturaMedicamento>>> InactivateFacturaMedicamento(int id);
        Task<ServiceResponse<List<FacturaMedicamento>>> ActivateFacturaMedicamento(int id);
    }
}
