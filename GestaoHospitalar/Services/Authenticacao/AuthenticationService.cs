using GestaoHospitalar.DataContext;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;

namespace GestaoHospitalar.Services.Authenticacao
{
    public class AuthenticationService: AuthenticationInterface
    {
        
        private readonly ApplicationDbContext _context;

        public AuthenticationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<UserAuthentication>> AuthenticateUser(string email, string password)
        {
            var serviceResponse = new ServiceResponse<UserAuthentication>();

            try
            {
                // Verifica se o email pertence a um Médico
                var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Email == email && m.Password == password);
                if (medico != null && medico.Status == true)
                {
                    serviceResponse.Data = new UserAuthentication
                    {
                        Email = medico.Email,
                        Password = null, // Nunca retorne a senha no response
                        Acesso = "Medico"
                    };
                    serviceResponse.menssage = "Authenticated as Medico.";
                    serviceResponse.Success = true;
                    return serviceResponse;
                }

                // Verifica se o email pertence a um Paciente
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
                if (paciente != null   && paciente.Status == true)
                {
                    serviceResponse.Data = new UserAuthentication
                    {
                        Email = paciente.Email,
                        Password = null,
                        Acesso = "Paciente"
                    };
                    serviceResponse.menssage = "Authenticated as Paciente.";
                    serviceResponse.Success = true;
                    return serviceResponse;
                }

                // Verifica se o email pertence a um Funcionário
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Email == email && f.Password == password);
                if (funcionario != null && funcionario.Status == true)
                {
                    serviceResponse.Data = new UserAuthentication
                    {
                        Email = funcionario.Email,
                        Password = null,
                        Acesso = "Funcionario"
                    };
                    serviceResponse.menssage = "Authenticated as Funcionario.";
                    serviceResponse.Success = true;
                    return serviceResponse;
                }

                // Caso nenhum usuário seja encontrado
                serviceResponse.Data = null;
                serviceResponse.menssage = "Invalid email or password.";
                serviceResponse.Success = false;
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

    }
}
