using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.AgendamentoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentoInterface _agendamentoInterface;

        public AgendamentoController(AgendamentoInterface agendamentoInterface)
        {
            _agendamentoInterface = agendamentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Agendamento>>>> GetAgendamentos()
        {
            return Ok(await _agendamentoInterface.GetAgendamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Agendamento>>> FindAgendamento(int id)
        {
            return Ok(await _agendamentoInterface.FindAgendamento(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Agendamento>>>> CreateAgendamento(AgendamentoView newAgendamento)
        {
            return Ok(await _agendamentoInterface.CreateAgendamento(newAgendamento));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Agendamento>>>> UpdateAgendamento(AgendamentoView updateAgendamento)
        {
            return Ok(await _agendamentoInterface.UpdateAgendamento(updateAgendamento));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Agendamento>>>> InactivateAgendamento(int id)
        {
            return Ok(await _agendamentoInterface.InactivateAgendamento(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Agendamento>>>> ActivateAgendamento(int id)
        {
            return Ok(await _agendamentoInterface.ActivateAgendamento(id));
        }
    }
}
