using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.FornecedorServices
{
    public interface FornecedorInterface
    {
        Task<ServiceResponse<List<Fornecedor>>> GetFornecedores();
        Task<ServiceResponse<Fornecedor>> FindFornecedor(int id);
        Task<ServiceResponse<List<Fornecedor>>> CreateFornecedor(FornecedorView newFornecedor);
        Task<ServiceResponse<List<Fornecedor>>> UpdateFornecedor(FornecedorView updateFornecedor);
        Task<ServiceResponse<List<Fornecedor>>> InactivateFornecedor(int id);
        Task<ServiceResponse<List<Fornecedor>>> ActivateFornecedor(int id);
    }
}
