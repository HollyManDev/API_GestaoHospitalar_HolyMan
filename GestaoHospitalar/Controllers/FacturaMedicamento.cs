using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.FacturaMedicamentoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaMedicamentoController : ControllerBase
    {
        private readonly FacturaMedicamentoInterface _facturaMedicamentoInterface;

        public FacturaMedicamentoController(FacturaMedicamentoInterface facturaMedicamentoInterface)
        {
            _facturaMedicamentoInterface = facturaMedicamentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FacturaMedicamento>>>> GetFacturasMedicamentos()
        {
            return Ok(await _facturaMedicamentoInterface.GetFacturasMedicamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FacturaMedicamento>>> FindFacturaMedicamento(int id)
        {
            return Ok(await _facturaMedicamentoInterface.FindFacturaMedicamento(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FacturaMedicamento>>>> CreateFacturaMedicamento(FacturaMedicamentoView newFacturaMedicamento)
        {
            return Ok(await _facturaMedicamentoInterface.CreateFacturaMedicamento(newFacturaMedicamento));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FacturaMedicamento>>>> UpdateFacturaMedicamento(FacturaMedicamentoView updateFacturaMedicamento)
        {
            return Ok(await _facturaMedicamentoInterface.UpdateFacturaMedicamento(updateFacturaMedicamento));
        }

        [HttpPost("inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<FacturaMedicamento>>>> InactivateFacturaMedicamento(int id)
        {
            return Ok(await _facturaMedicamentoInterface.InactivateFacturaMedicamento(id));
        }

        [HttpPost("activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<FacturaMedicamento>>>> ActivateFacturaMedicamento(int id)
        {
            return Ok(await _facturaMedicamentoInterface.ActivateFacturaMedicamento(id));
        }
    }
}
