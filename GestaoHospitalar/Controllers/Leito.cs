using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.LeitoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeitoController : ControllerBase
    {
        private readonly LeitoInterface _leitoService;

        public LeitoController(LeitoInterface leitoService)
        {
            _leitoService = leitoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Leito>>>> GetLeitos()
        {
            var response = await _leitoService.GetLeitos();
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Leito>>> GetLeito(int id)
        {
            var response = await _leitoService.FindLeito(id);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Leito>>>> CreateLeito(LeitoView leitoView)
        {
            var response = await _leitoService.CreateLeito(leitoView);
            if (response.Success)
                return CreatedAtAction(nameof(GetLeito), new { id = leitoView.LeitoID }, response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Leito>>>> UpdateLeito(LeitoView leitoView)
        {
            var response = await _leitoService.UpdateLeito(leitoView);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<List<Leito>>>> DeleteLeito(LeitoView leito)
        {
            var response = await _leitoService.DeleteLeito(leito.LeitoID);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }
    }
}
