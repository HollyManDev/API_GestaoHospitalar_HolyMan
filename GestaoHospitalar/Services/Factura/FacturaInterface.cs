using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.FacturaServices
{
    public interface FacturaInterface
    {
        Task<ServiceResponse<List<Factura>>> GetFacturas();
        Task<ServiceResponse<Factura>> FindFactura(int id);
        Task<ServiceResponse<List<Factura>>> CreateFactura(FacturaView newFactura);
        Task<ServiceResponse<List<Factura>>> UpdateFactura(FacturaView updateFactura);
        Task<ServiceResponse<List<Factura>>> InactivateFactura(int id);
        Task<ServiceResponse<List<Factura>>> ActivateFactura(int id);
    }
}
