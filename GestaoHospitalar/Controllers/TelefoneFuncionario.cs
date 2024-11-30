using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.TelefoneFuncionarioServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneFuncionarioController : ControllerBase
    {
        private readonly TelefoneFuncionarioInterface _telefoneFuncionarioInterface;

        public TelefoneFuncionarioController(TelefoneFuncionarioInterface telefoneFuncionarioInterface)
        {
            _telefoneFuncionarioInterface = telefoneFuncionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TelefoneFuncionario>>>> GetTelefonesFuncionarios()
        {
            return Ok(await _telefoneFuncionarioInterface.GetTelefonesFuncionarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TelefoneFuncionario>>> FindTelefoneFuncionario(int id)
        {
            return Ok(await _telefoneFuncionarioInterface.FindTelefoneFuncionario(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TelefoneFuncionario>>>> CreateTelefoneFuncionario(TelefoneFuncionarioView newTelefoneFuncionarioView)
        {
            return Ok(await _telefoneFuncionarioInterface.CreateTelefoneFuncionario(newTelefoneFuncionarioView));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TelefoneFuncionario>>>> UpdateTelefoneFuncionario(TelefoneFuncionarioView updatedTelefoneFuncionarioView)
        {
            return Ok(await _telefoneFuncionarioInterface.UpdateTelefoneFuncionario(updatedTelefoneFuncionarioView));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<TelefoneFuncionario>>>> DeleteTelefoneFuncionario(int id)
        {
            return Ok(await _telefoneFuncionarioInterface.DeleteTelefoneFuncionario(id));
        }
    }
}
