using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.FuncionarioServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioInterface _funcionarioInterface;

        public FuncionarioController(FuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> FindFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.FindFuncionario(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> CreateFuncionario(FuncionarioView newFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(newFuncionario));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> UpdateFuncionario(FuncionarioView updateFuncionario)
        {
            return Ok(await _funcionarioInterface.UpdateFuncionario(updateFuncionario));
        }

        [HttpPut("Inactivate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> InactivateFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.InactivateFuncionario(id));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> ActivateFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.ActivateFuncionario(id));
        }
    }
}
