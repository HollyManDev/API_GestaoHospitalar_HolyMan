using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;

namespace GestaoHospitalar.Services.ContactoEmergencia
{
    public interface contatoEmergenciaInterface
    {

        Task<ServiceResponse<List<ContatoEmergencia>>> GetContatosEmergencia();
        Task<ServiceResponse<ContatoEmergencia>> FindContatoEmergencia(int id);
        Task<ServiceResponse<List<ContatoEmergencia>>> CreateContatoEmergencia(ContatoEmergenciaView newContatoEmergencia);
        Task<ServiceResponse<List<ContatoEmergencia>>> UpdateContatoEmergencia(ContatoEmergenciaView updateContatoEmergencia);
        Task<ServiceResponse<List<ContatoEmergencia>>> DeleteContatoEmergencia(int id);
    }
}
