using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.PacienteServices;
using Microsoft.AspNetCore.Mvc;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteInterface _pacienteInterface;

        public PacienteController(PacienteInterface pacienteInterface)
        {
            _pacienteInterface = pacienteInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Paciente>>>> GetPacientes()
        {
            return Ok(await _pacienteInterface.GetPacientes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Paciente>>> FindPaciente(int id)
        {
            return Ok(await _pacienteInterface.FindPaciente(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Paciente>>>> CreatePaciente(PacienteView newPaciente)
        {
            return Ok(await _pacienteInterface.CreatePaciente(newPaciente));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Paciente>>>> UpdatePaciente(PacienteView updatePaciente)
        {
            return Ok(await _pacienteInterface.UpdatePaciente(updatePaciente));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Paciente>>>> InactivatePaciente(int id)
        {
            return Ok(await _pacienteInterface.InactivatePaciente(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Paciente>>>> ActivatePaciente(int id)
        {
            return Ok(await _pacienteInterface.ActivatePaciente(id));
        }
    }
}
