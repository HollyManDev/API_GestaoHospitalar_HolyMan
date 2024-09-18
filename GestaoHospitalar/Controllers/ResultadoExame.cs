using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.ResultadoExameServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoExameController : ControllerBase
    {
        private readonly ResultadoExameInterface _resultadoExameInterface;

        public ResultadoExameController(ResultadoExameInterface resultadoExameInterface)
        {
            _resultadoExameInterface = resultadoExameInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ResultadoExame>>>> GetResultadosExames()
        {
            return Ok(await _resultadoExameInterface.GetResultadosExames());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ResultadoExame>>> FindResultadoExame(int id)
        {
            return Ok(await _resultadoExameInterface.FindResultadoExame(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ResultadoExame>>>> CreateResultadoExame(ResultadoExameView newResultadoExame)
        {
            return Ok(await _resultadoExameInterface.CreateResultadoExame(newResultadoExame));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ResultadoExame>>>> UpdateResultadoExame(ResultadoExameView updateResultadoExame)
        {
            return Ok(await _resultadoExameInterface.UpdateResultadoExame(updateResultadoExame));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ResultadoExame>>>> InactivateResultadoExame(int id)
        {
            return Ok(await _resultadoExameInterface.InactivateResultadoExame(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ResultadoExame>>>> ActivateResultadoExame(int id)
        {
            return Ok(await _resultadoExameInterface.ActivateResultadoExame(id));
        }
    }
}
