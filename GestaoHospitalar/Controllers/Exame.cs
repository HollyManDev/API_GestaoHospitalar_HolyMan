using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.ExameServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly ExameInterface _exameInterface;

        public ExameController(ExameInterface exameInterface)
        {
            _exameInterface = exameInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Exame>>>> GetExames()
        {
            return Ok(await _exameInterface.GetExames());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Exame>>> FindExame(int id)
        {
            return Ok(await _exameInterface.FindExame(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Exame>>>> CreateExame(ExameView newExame)
        {
            return Ok(await _exameInterface.CreateExame(newExame));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Exame>>>> UpdateExame(ExameView updateExame)
        {
            return Ok(await _exameInterface.UpdateExame(updateExame));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Exame>>>> InactivateExame(int id)
        {
            return Ok(await _exameInterface.InactivateExame(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Exame>>>> ActivateExame(int id)
        {
            return Ok(await _exameInterface.ActivateExame(id));
        }
    }
}
