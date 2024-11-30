using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.Authenticacao;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationInterface _authService;

        public AuthenticationController(AuthenticationInterface authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<UserAuthentication>>> Login([FromBody] UserAuthentication loginRequest)
        {
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return BadRequest(new ServiceResponse<UserAuthentication>
                {
                    Success = false,
                    menssage = "Invalid login request. Email and password are required."
                });
            }

            var response = await _authService.AuthenticateUser(loginRequest.Email, loginRequest.Password);

            if (!response.Success)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }
    }
}
