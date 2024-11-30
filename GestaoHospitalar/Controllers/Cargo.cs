using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services;
using GestaoHospitalar.Services.CargoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly CargoInterface _cargoService;

        public CargoController (CargoInterface cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Cargo>>>> GetCargos()
        {
            var response = await _cargoService.GetCargos();
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Cargo>>> GetCargo(int id)
        {
            var response = await _cargoService.FindCargo(id);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Cargo>>>> CreateCargo(CargoView leitoView)
        {
            var response = await _cargoService.CreateCargo(leitoView);
            if (response.Success)
                return CreatedAtAction(nameof(GetCargo), new { id = leitoView.CargoID }, response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Cargo>>>> UpdateCargo(CargoView leitoView)
        {
            var response = await _cargoService.UpdateCargo(leitoView);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<List<Cargo>>>> DeleteCargo(CargoView leito)
        {
            var response = await _cargoService.DeleteCargo(leito.CargoID);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }
    }
}
