using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.OutroServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutroController : ControllerBase
    {
        private readonly OutroInterface _outroService;

        public OutroController(OutroInterface outroService)
        {
            _outroService = outroService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Outro>>>> GetOutros()
        {
            var response = await _outroService.GetOutros();
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Outro>>> GetOutro(int id)
        {
            var response = await _outroService.FindOutro(id);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Outro>>>> CreateOutro(OutroView outroView)
        {
            var response = await _outroService.CreateOutro(outroView);
            if (response.Success)
                return CreatedAtAction(nameof(GetOutro), new { id = outroView.Id }, response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Outro>>>> UpdateOutro(OutroView outroView)
        {
            var response = await _outroService.UpdateOutro(outroView);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<List<Outro>>>> DeleteOutro(OutroView outro)
        {
            var response = await _outroService.DeleteOutro(outro.Id);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }
    }
}
