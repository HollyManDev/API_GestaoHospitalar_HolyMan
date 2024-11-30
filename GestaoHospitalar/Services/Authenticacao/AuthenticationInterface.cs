using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;

namespace GestaoHospitalar.Services.Authenticacao
{
    public interface AuthenticationInterface
    {
        Task<ServiceResponse<UserAuthentication>> AuthenticateUser(string email, string password);
    }
}
