using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.InventarioMedicamentoServices
{
    public class InventarioMedicamentoService : InventarioMedicamentoInterface
    {
        private readonly ApplicationDbContext _context;

        public InventarioMedicamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<InventarioMedicamento>>> GetInventarioMedicamentos()
        {
            var serviceResponse = new ServiceResponse<List<InventarioMedicamento>>();

            try
            {
                serviceResponse.Data = await _context.InventarioMedicamentos
                    .Include(i => i.Fornecedor) // Incluindo o Fornecedor relacionado
                    .ToListAsync();
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

        public async Task<ServiceResponse<InventarioMedicamento>> FindInventarioMedicamento(int id)
        {
            var serviceResponse = new ServiceResponse<InventarioMedicamento>();

            try
            {
                var inventarioMedicamento = await _context.InventarioMedicamentos
                    .Include(i => i.Fornecedor) // Incluindo o Fornecedor relacionado
                    .FirstOrDefaultAsync(i => i.MedicamentoID == id);

                if (inventarioMedicamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "InventarioMedicamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = inventarioMedicamento;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<InventarioMedicamento>>> CreateInventarioMedicamento(InventarioMedicamentoView newInventarioMedicamento)
        {
            var serviceResponse = new ServiceResponse<List<InventarioMedicamento>>();

            try
            {
                var inventarioMedicamento = new InventarioMedicamento
                {
                    Nome = newInventarioMedicamento.Nome,
                    Quantidade = newInventarioMedicamento.Quantidade,
                    DataValidade = newInventarioMedicamento.DataValidade,
                    FornecedorID = newInventarioMedicamento.FornecedorID,
                    Status = true
                };

                _context.InventarioMedicamentos.Add(inventarioMedicamento);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.InventarioMedicamentos.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<InventarioMedicamento>>> UpdateInventarioMedicamento(InventarioMedicamentoView updateInventarioMedicamento)
        {
            var serviceResponse = new ServiceResponse<List<InventarioMedicamento>>();

            try
            {
                var inventarioMedicamento = await _context.InventarioMedicamentos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.MedicamentoID == updateInventarioMedicamento.MedicamentoID);

                if (inventarioMedicamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "InventarioMedicamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    inventarioMedicamento.Nome = updateInventarioMedicamento.Nome;
                    inventarioMedicamento.Quantidade = updateInventarioMedicamento.Quantidade;
                    inventarioMedicamento.DataValidade = updateInventarioMedicamento.DataValidade;
                    inventarioMedicamento.FornecedorID = updateInventarioMedicamento.FornecedorID;
                    inventarioMedicamento.Status = updateInventarioMedicamento.Status;

                    _context.InventarioMedicamentos.Update(inventarioMedicamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.InventarioMedicamentos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<InventarioMedicamento>>> InactivateInventarioMedicamento(int id)
        {
            var serviceResponse = new ServiceResponse<List<InventarioMedicamento>>();

            try
            {
                var inventarioMedicamento = await _context.InventarioMedicamentos.FirstOrDefaultAsync(i => i.MedicamentoID == id);

                if (inventarioMedicamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "InventarioMedicamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    inventarioMedicamento.Status = false;
                    _context.InventarioMedicamentos.Update(inventarioMedicamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.InventarioMedicamentos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<InventarioMedicamento>>> ActivateInventarioMedicamento(int id)
        {
            var serviceResponse = new ServiceResponse<List<InventarioMedicamento>>();

            try
            {
                var inventarioMedicamento = await _context.InventarioMedicamentos.FirstOrDefaultAsync(i => i.MedicamentoID == id);

                if (inventarioMedicamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "InventarioMedicamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    inventarioMedicamento.Status = true;
                    _context.InventarioMedicamentos.Update(inventarioMedicamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.InventarioMedicamentos.ToListAsync();
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
