using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.HistoricoAtendimentoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoAtendimentoController : ControllerBase
    {
        private readonly HistoricoAtendimentoInterface _historicoAtendimentoInterface;

        public HistoricoAtendimentoController(HistoricoAtendimentoInterface historicoAtendimentoInterface)
        {
            _historicoAtendimentoInterface = historicoAtendimentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<HistoricoAtendimento>>>> GetHistoricosAtendimento()
        {
            return Ok(await _historicoAtendimentoInterface.GetHistoricosAtendimento());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<HistoricoAtendimento>>> FindHistoricoAtendimento(int id)
        {
            return Ok(await _historicoAtendimentoInterface.FindHistoricoAtendimento(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<HistoricoAtendimento>>>> CreateHistoricoAtendimento(HistoricoAtendimentoView newHistoricoAtendimento)
        {
            return Ok(await _historicoAtendimentoInterface.CreateHistoricoAtendimento(newHistoricoAtendimento));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<HistoricoAtendimento>>>> UpdateHistoricoAtendimento(HistoricoAtendimentoView updateHistoricoAtendimento)
        {
            return Ok(await _historicoAtendimentoInterface.UpdateHistoricoAtendimento(updateHistoricoAtendimento));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<HistoricoAtendimento>>>> InactivateHistoricoAtendimento(int id)
        {
            return Ok(await _historicoAtendimentoInterface.InactivateHistoricoAtendimento(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<HistoricoAtendimento>>>> ActivateHistoricoAtendimento(int id)
        {
            return Ok(await _historicoAtendimentoInterface.ActivateHistoricoAtendimento(id));
        }
    }
}
