using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.EspecialidadeServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly EspecialidadeInterface _especialidadeService;

        public EspecialidadeController(EspecialidadeInterface especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Especialidade>>>> GetEspecialidades()
        {
            var response = await _especialidadeService.GetEspecialidades();
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Especialidade>>> GetEspecialidade(int id)
        {
            var response = await _especialidadeService.FindEspecialidade(id);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Especialidade>>>> CreateEspecialidade(EspecialidadeView especialidadeView)
        {
            var response = await _especialidadeService.CreateEspecialidade(especialidadeView);
            if (response.Success)
                return CreatedAtAction(nameof(GetEspecialidade), new { id = especialidadeView.EspecialidadeID }, response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Especialidade>>>> UpdateEspecialidade(EspecialidadeView especialidadeView)
        {
            var response = await _especialidadeService.UpdateEspecialidade(especialidadeView);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPut("Delete")]
        public async Task<ActionResult<ServiceResponse<List<Especialidade>>>> DeleteEspecialidade(EspecialidadeView esp)
        {
            var response = await _especialidadeService.DeleteEspecialidade(esp.EspecialidadeID);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }
    }
}
