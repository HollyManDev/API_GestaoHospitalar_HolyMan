using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.DepartamentoServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoInterface _departamentoInterface;

        public DepartamentoController(DepartamentoInterface departamentoInterface)
        {
            _departamentoInterface = departamentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DepartamentosFuncionarios>>>> GetDepartamentos()
        {
            return Ok(await _departamentoInterface.GetDepartamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<DepartamentosFuncionarios>>> FindDepartamento(int id)
        {
            return Ok(await _departamentoInterface.FindDepartamento(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DepartamentosFuncionarios>>>> CreateDepartamento(DepartamentoView newDepartamento)
        {
            return Ok(await _departamentoInterface.CreateDepartamento(newDepartamento));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<DepartamentosFuncionarios>>>> UpdateDepartamento(DepartamentoView updateDepartamento)
        {
            return Ok(await _departamentoInterface.UpdateDepartamento(updateDepartamento));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<DepartamentosFuncionarios>>>> InactivateDepartamento(int id)
        {
            return Ok(await _departamentoInterface.InactivateDepartamento(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<DepartamentosFuncionarios>>>> ActivateDepartamento(int id)
        {
            return Ok(await _departamentoInterface.ActivateDepartamento(id));
        }
    }
}
