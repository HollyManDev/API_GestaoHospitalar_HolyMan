using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ConsultaServices
{
    public interface ConsultaInterface
    {
        Task<ServiceResponse<List<Consulta>>> GetConsultas();
        Task<ServiceResponse<Consulta>> FindConsulta(int id);
        Task<ServiceResponse<List<Consulta>>> CreateConsulta(ConsultaView newConsulta);
        Task<ServiceResponse<List<Consulta>>> UpdateConsulta(ConsultaView updateConsulta);
        Task<ServiceResponse<List<Consulta>>> InactivateConsulta(int id);
        Task<ServiceResponse<List<Consulta>>> ActivateConsulta(int id);
    }
}
