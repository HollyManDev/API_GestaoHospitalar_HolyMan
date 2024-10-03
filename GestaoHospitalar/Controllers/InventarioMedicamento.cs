using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.InventarioMedicamentoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioMedicamentoController : ControllerBase
    {
        private readonly InventarioMedicamentoInterface _inventarioMedicamentoInterface;

        public InventarioMedicamentoController(InventarioMedicamentoInterface inventarioMedicamentoInterface)
        {
            _inventarioMedicamentoInterface = inventarioMedicamentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<InventarioMedicamento>>>> GetInventarioMedicamentos()
        {
            return Ok(await _inventarioMedicamentoInterface.GetInventarioMedicamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<InventarioMedicamento>>> FindInventarioMedicamento(int id)
        {
            return Ok(await _inventarioMedicamentoInterface.FindInventarioMedicamento(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<InventarioMedicamento>>>> CreateInventarioMedicamento(InventarioMedicamentoView newInventarioMedicamento)
        {
            return Ok(await _inventarioMedicamentoInterface.CreateInventarioMedicamento(newInventarioMedicamento));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<InventarioMedicamento>>>> UpdateInventarioMedicamento(InventarioMedicamentoView updateInventarioMedicamento)
        {
            return Ok(await _inventarioMedicamentoInterface.UpdateInventarioMedicamento(updateInventarioMedicamento));
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<List<InventarioMedicamento>>>> InactivateInventarioMedicamento(InventarioMedicamentoView medicamento)
        {
            return Ok(await _inventarioMedicamentoInterface.InactivateInventarioMedicamento(medicamento.MedicamentoID));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<InventarioMedicamento>>>> ActivateInventarioMedicamento(int id)
        {
            return Ok(await _inventarioMedicamentoInterface.ActivateInventarioMedicamento(id));
        }
    }
}
