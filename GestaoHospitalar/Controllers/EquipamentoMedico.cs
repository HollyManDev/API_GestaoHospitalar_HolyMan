using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.EquipamentoMedicoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoMedicoController : ControllerBase
    {
        private readonly EquipamentoMedicoInterface _equipamentoMedicoService;

        public EquipamentoMedicoController(EquipamentoMedicoInterface equipamentoMedicoService)
        {
            _equipamentoMedicoService = equipamentoMedicoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> GetEquipamentosMedicos()
        {
            return Ok(await _equipamentoMedicoService.GetEquipamentosMedicos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EquipamentoMedico>>> GetEquipamentoMedico(int id)
        {
            return Ok(await _equipamentoMedicoService.FindEquipamentoMedico(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> PostEquipamentoMedico(EquipamentoMedicoView equipamentoMedicoView)
        {
            return Ok(await _equipamentoMedicoService.CreateEquipamentoMedico(equipamentoMedicoView));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> PutEquipamentoMedico(EquipamentoMedicoView equipamentoMedicoView)
        {
            return Ok(await _equipamentoMedicoService.UpdateEquipamentoMedico(equipamentoMedicoView));
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> InactivateEquipamentoMedico(EquipamentoMedicoView equipamento)
        {
            return Ok(await _equipamentoMedicoService.InactivateEquipamentoMedico(equipamento.EquipamentoID));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<EquipamentoMedico>>>> ActivateEquipamentoMedico(int id)
        {
            return Ok(await _equipamentoMedicoService.ActivateEquipamentoMedico(id));
        }
    }
}
