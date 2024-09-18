using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.PrescricaoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescricaoController : ControllerBase
    {
        private readonly PrescricaoInterface _prescricaoInterface;

        public PrescricaoController(PrescricaoInterface prescricaoInterface)
        {
            _prescricaoInterface = prescricaoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Prescricao>>>> GetPrescricoes()
        {
            return Ok(await _prescricaoInterface.GetPrescricoes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Prescricao>>> FindPrescricao(int id)
        {
            return Ok(await _prescricaoInterface.FindPrescricao(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Prescricao>>>> CreatePrescricao(PrecricaoView newPrescricao)
        {
            return Ok(await _prescricaoInterface.CreatePrescricao(newPrescricao));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Prescricao>>>> UpdatePrescricao(PrecricaoView updatePrescricao)
        {
            return Ok(await _prescricaoInterface.UpdatePrescricao(updatePrescricao));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Prescricao>>>> InactivatePrescricao(int id)
        {
            return Ok(await _prescricaoInterface.InactivatePrescricao(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Prescricao>>>> ActivatePrescricao(int id)
        {
            return Ok(await _prescricaoInterface.ActivatePrescricao(id));
        }
    }
}
