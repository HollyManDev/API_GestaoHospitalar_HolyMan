using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.EquipamentoMedicoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoMedicoController : ControllerBase
    {
        private readonly EquipamentoMedicoInterface _equipamentoMedicoService;

        public EquipamentoMedicoController(EquipamentoMedicoInterface equipamentoMedicoService)
        {
            _equipamentoMedicoService = equipamentoMedicoService;
        }

        // GET: api/EquipamentoMedico
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> GetEquipamentosMedicos()
        {
            var response = await _equipamentoMedicoService.GetEquipamentosMedicos();
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // GET: api/EquipamentoMedico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EquipamentoMedico>>> GetEquipamentoMedico(int id)
        {
            var response = await _equipamentoMedicoService.FindEquipamentoMedico(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // POST: api/EquipamentoMedico
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> PostEquipamentoMedico(EquipamentoMedicoView equipamentoMedicoView)
        {
            var response = await _equipamentoMedicoService.CreateEquipamentoMedico(equipamentoMedicoView);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetEquipamentoMedico), new { id = response.Data.Last().EquipamentoID }, response);
            }
            return BadRequest(response);
        }

        // PUT: api/EquipamentoMedico/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> PutEquipamentoMedico(int id, EquipamentoMedicoView equipamentoMedicoView)
        {
            if (id != equipamentoMedicoView.EquipamentoID)
            {
                return BadRequest();
            }

            var response = await _equipamentoMedicoService.UpdateEquipamentoMedico(equipamentoMedicoView);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // DELETE: api/EquipamentoMedico/Inactivate/5
        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> InactivateEquipamentoMedico(int id)
        {
            var response = await _equipamentoMedicoService.InactivateEquipamentoMedico(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // PUT: api/EquipamentoMedico/Activate/5
        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> ActivateEquipamentoMedico(int id)
        {
            var response = await _equipamentoMedicoService.ActivateEquipamentoMedico(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
