using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.FacturaServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaInterface _facturaInterface;

        public FacturaController(FacturaInterface facturaInterface)
        {
            _facturaInterface = facturaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Factura>>>> GetFacturas()
        {
            return Ok(await _facturaInterface.GetFacturas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Factura>>> FindFactura(int id)
        {
            return Ok(await _facturaInterface.FindFactura(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Factura>>>> CreateFactura(FacturaView newFactura)
        {
            return Ok(await _facturaInterface.CreateFactura(newFactura));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Factura>>>> UpdateFactura(FacturaView updateFactura)
        {
            return Ok(await _facturaInterface.UpdateFactura(updateFactura));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Factura>>>> InactivateFactura(int id)
        {
            return Ok(await _facturaInterface.InactivateFactura(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Factura>>>> ActivateFactura(int id)
        {
            return Ok(await _facturaInterface.ActivateFactura(id));
        }
    }
}
