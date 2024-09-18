using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.FornecedorServices
{
    public class FornecedorService : FornecedorInterface
    {
        private readonly ApplicationDbContext _context;

        public FornecedorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Fornecedor>>> GetFornecedores()
        {
            var serviceResponse = new ServiceResponse<List<Fornecedor>>();

            try
            {
                serviceResponse.Data = await _context.Fornecedores.ToListAsync();
                if (!serviceResponse.Data.Any())
                {
                    serviceResponse.menssage = "No data available!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Fornecedor>> FindFornecedor(int id)
        {
            var serviceResponse = new ServiceResponse<Fornecedor>();

            try
            {
                var fornecedor = await _context.Fornecedores
                    .Include(f => f.InventarioMedicamentos) // Incluindo o InventarioMedicamento relacionado
                    .FirstOrDefaultAsync(f => f.FornecedorID == id);

                if (fornecedor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Fornecedor not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = fornecedor;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Fornecedor>>> CreateFornecedor(FornecedorView newFornecedor)
        {
            var serviceResponse = new ServiceResponse<List<Fornecedor>>();

            try
            {
                var fornecedor = new Fornecedor
                {
                    Nome = newFornecedor.Nome,
                    Contato = newFornecedor.Contato,
                    Telefone = newFornecedor.Telefone,
                    Email = newFornecedor.Email,
                    Status = newFornecedor.Status
                };

                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Fornecedores.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Fornecedor>>> UpdateFornecedor(FornecedorView updateFornecedor)
        {
            var serviceResponse = new ServiceResponse<List<Fornecedor>>();

            try
            {
                var fornecedor = await _context.Fornecedores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(f => f.FornecedorID == updateFornecedor.FornecedorID);

                if (fornecedor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Fornecedor not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    fornecedor.Nome = updateFornecedor.Nome;
                    fornecedor.Contato = updateFornecedor.Contato;
                    fornecedor.Telefone = updateFornecedor.Telefone;
                    fornecedor.Email = updateFornecedor.Email;
                    fornecedor.Status = updateFornecedor.Status;

                    _context.Fornecedores.Update(fornecedor);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Fornecedores.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Fornecedor>>> InactivateFornecedor(int id)
        {
            var serviceResponse = new ServiceResponse<List<Fornecedor>>();

            try
            {
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(f => f.FornecedorID == id);

                if (fornecedor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Fornecedor not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    fornecedor.Status = false; // Assumindo que você tem um campo de Status
                    _context.Fornecedores.Update(fornecedor);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Fornecedores.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Fornecedor>>> ActivateFornecedor(int id)
        {
            var serviceResponse = new ServiceResponse<List<Fornecedor>>();

            try
            {
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(f => f.FornecedorID == id);

                if (fornecedor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Fornecedor not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    fornecedor.Status = true; // Assumindo que você tem um campo de Status
                    _context.Fornecedores.Update(fornecedor);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Fornecedores.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
