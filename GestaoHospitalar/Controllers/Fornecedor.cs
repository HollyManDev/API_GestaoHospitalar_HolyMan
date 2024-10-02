using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.FornecedorServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorInterface _fornecedorInterface;

        public FornecedorController(FornecedorInterface fornecedorInterface)
        {
            _fornecedorInterface = fornecedorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Fornecedor>>>> GetFornecedores()
        {
            return Ok(await _fornecedorInterface.GetFornecedores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Fornecedor>>> FindFornecedor(int id)
        {
            return Ok(await _fornecedorInterface.FindFornecedor(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Fornecedor>>>> CreateFornecedor(FornecedorView newFornecedor)
        {
            return Ok(await _fornecedorInterface.CreateFornecedor(newFornecedor));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Fornecedor>>>> UpdateFornecedor(FornecedorView updateFornecedor)
        {
            return Ok(await _fornecedorInterface.UpdateFornecedor(updateFornecedor));
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<List<Fornecedor>>>> InactivateFornecedor(FornecedorView forn)
        {
            return Ok(await _fornecedorInterface.InactivateFornecedor(forn.FornecedorID));
        }

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Fornecedor>>>> ActivateFornecedor(int id)
        {
            return Ok(await _fornecedorInterface.ActivateFornecedor(id));
        }
    }
}
