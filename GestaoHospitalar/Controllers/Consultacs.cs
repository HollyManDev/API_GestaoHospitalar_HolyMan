using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.ConsultaServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaInterface _consultaInterface;

        public ConsultaController(ConsultaInterface consultaInterface)
        {
            _consultaInterface = consultaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Consulta>>>> GetConsultas()
        {
            return Ok(await _consultaInterface.GetConsultas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Consulta>>> FindConsulta(int id)
        {
            return Ok(await _consultaInterface.FindConsulta(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Consulta>>>> CreateConsulta(ConsultaView newConsulta)
        {
            return Ok(await _consultaInterface.CreateConsulta(newConsulta));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Consulta>>>> UpdateConsulta(ConsultaView updateConsulta)
        {
            return Ok(await _consultaInterface.UpdateConsulta(updateConsulta));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Consulta>>>> InactivateConsulta(int id)
        {
            return Ok(await _consultaInterface.InactivateConsulta(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Consulta>>>> ActivateConsulta(int id)
        {
            return Ok(await _consultaInterface.ActivateConsulta(id));
        }
    }
}
