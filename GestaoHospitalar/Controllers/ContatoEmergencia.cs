using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.ContactoEmergencia;
using GestaoHospitalar.Services.ContatoEmergenciaServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoEmergenciaController : ControllerBase
    {
        private readonly contatoEmergenciaInterface _contatoEmergenciaInterface;

        public ContatoEmergenciaController(contatoEmergenciaInterface contatoEmergenciaInterface)
        {
            _contatoEmergenciaInterface = contatoEmergenciaInterface;
        }

        // GET: api/ContatoEmergencia
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ContatoEmergencia>>>> GetContatosEmergencia()
        {
            return Ok(await _contatoEmergenciaInterface.GetContatosEmergencia());
        }

        // GET: api/ContatoEmergencia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ContatoEmergencia>>> FindContatoEmergencia(int id)
        {
            return Ok(await _contatoEmergenciaInterface.FindContatoEmergencia(id));
        }

        // POST: api/ContatoEmergencia
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ContatoEmergencia>>>> CreateContatoEmergencia(ContatoEmergenciaView newContatoEmergencia)
        {
            return Ok(await _contatoEmergenciaInterface.CreateContatoEmergencia(newContatoEmergencia));
        }

        // PUT: api/ContatoEmergencia
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ContatoEmergencia>>>> UpdateContatoEmergencia(ContatoEmergenciaView updateContatoEmergencia)
        {
            return Ok(await _contatoEmergenciaInterface.UpdateContatoEmergencia(updateContatoEmergencia));
        }

        // DELETE: api/ContatoEmergencia/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ContatoEmergencia>>>> DeleteContatoEmergencia(int id)
        {
            return Ok(await _contatoEmergenciaInterface.DeleteContatoEmergencia(id));
        }
    }
}
