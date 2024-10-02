using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.CamaServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamaController : ControllerBase
    {
        private readonly CamaInterface _camaService;

        public CamaController(CamaInterface camaService)
        {
            _camaService = camaService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Cama>>>> GetCamas()
        {
            var response = await _camaService.GetCamas();
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Cama>>> GetCama(int id)
        {
            var response = await _camaService.FindCama(id);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Cama>>>> CreateCama(CamaView camaView)
        {
            var response = await _camaService.CreateCama(camaView);
            if (response.Success)
                return CreatedAtAction(nameof(GetCama), new { id = camaView.CamaID }, response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Cama>>>> UpdateCama(CamaView camaView)
        {
            var response = await _camaService.UpdateCama(camaView);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<List<Cama>>>> DeleteCama(CamaView camaView)
        {
            var response = await _camaService.DeleteCama(camaView.CamaID);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }
    }
}
