using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.ReciboServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciboController : ControllerBase
    {
        private readonly ReciboInterface _reciboInterface;

        public ReciboController(ReciboInterface reciboInterface)
        {
            _reciboInterface = reciboInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Recibo>>>> GetRecibos()
        {
            return Ok(await _reciboInterface.GetRecibos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Recibo>>> FindRecibo(int id)
        {
            return Ok(await _reciboInterface.FindRecibo(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Recibo>>>> CreateRecibo(ReciboView newRecibo)
        {
            return Ok(await _reciboInterface.CreateRecibo(newRecibo));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Recibo>>>> UpdateRecibo(ReciboView updateRecibo)
        {
            return Ok(await _reciboInterface.UpdateRecibo(updateRecibo));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Recibo>>>> InactivateRecibo(int id)
        {
            return Ok(await _reciboInterface.InactivateRecibo(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Recibo>>>> ActivateRecibo(int id)
        {
            return Ok(await _reciboInterface.ActivateRecibo(id));
        }
    }
}
