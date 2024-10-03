using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.MedicoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoInterface _medicoService;

        public MedicoController(MedicoInterface medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Medico>>>> GetMedicos()
        {
            var response = await _medicoService.GetMedicos();
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Medico>>> GetMedico(int id)
        {
            var response = await _medicoService.FindMedico(id);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Medico>>>> CreateMedico(MedicoView medicoView)
        {
            var response = await _medicoService.CreateMedico(medicoView);
            if (response.Success)
                return CreatedAtAction(nameof(GetMedico), new { id = medicoView.MedicoID }, response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Medico>>>> UpdateMedico(MedicoView medicoView)
        {
            var response = await _medicoService.UpdateMedico(medicoView);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<List<Medico>>>> DeleteMedico(MedicoView medico)
        {
            var response = await _medicoService.DeleteMedico(medico.MedicoID);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }
    }
}
