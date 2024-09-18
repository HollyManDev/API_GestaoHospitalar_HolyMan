using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.FacturaMedicamentoServices
{
    public class FacturaMedicamentoService : FacturaMedicamentoInterface
    {
        private readonly ApplicationDbContext _context;

        public FacturaMedicamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FacturaMedicamento>>> GetFacturasMedicamentos()
        {
            var serviceResponse = new ServiceResponse<List<FacturaMedicamento>>();

            try
            {
                serviceResponse.Data = await _context.FacturasMedicamentos
                    .Include(fm => fm.Factura)
                    .Include(fm => fm.Medicamento)
                    .Where(fm => fm.status) // Filter by active status
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

        public async Task<ServiceResponse<FacturaMedicamento>> FindFacturaMedicamento(int id)
        {
            var serviceResponse = new ServiceResponse<FacturaMedicamento>();

            try
            {
                var facturaMedicamento = await _context.FacturasMedicamentos
                    .Include(fm => fm.Factura)
                    .Include(fm => fm.Medicamento)
                    .FirstOrDefaultAsync(fm => fm.FacturaMedicamentoID == id && fm.status);

                if (facturaMedicamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "FacturaMedicamento not found or inactive!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = facturaMedicamento;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FacturaMedicamento>>> CreateFacturaMedicamento(FacturaMedicamentoView newFacturaMedicamento)
        {
            var serviceResponse = new ServiceResponse<List<FacturaMedicamento>>();

            try
            {
                var facturaMedicamento = new FacturaMedicamento
                {
                    FaturaID = newFacturaMedicamento.FaturaID,
                    MedicamentoID = newFacturaMedicamento.MedicamentoID,
                    Quantidade = newFacturaMedicamento.Quantidade,
                    PrecoUnitario = newFacturaMedicamento.PrecoUnitario,
                    PrecoTotal = newFacturaMedicamento.PrecoTotal,
                    status = newFacturaMedicamento.status
                };

                _context.FacturasMedicamentos.Add(facturaMedicamento);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.FacturasMedicamentos
                    .Where(fm => fm.status)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FacturaMedicamento>>> UpdateFacturaMedicamento(FacturaMedicamentoView updateFacturaMedicamento)
        {
            var serviceResponse = new ServiceResponse<List<FacturaMedicamento>>();

            try
            {
                var facturaMedicamento = await _context.FacturasMedicamentos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(fm => fm.FacturaMedicamentoID == updateFacturaMedicamento.FacturaMedicamentoID);

                if (facturaMedicamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "FacturaMedicamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    facturaMedicamento.FaturaID = updateFacturaMedicamento.FaturaID;
                    facturaMedicamento.MedicamentoID = updateFacturaMedicamento.MedicamentoID;
                    facturaMedicamento.Quantidade = updateFacturaMedicamento.Quantidade;
                    facturaMedicamento.PrecoUnitario = updateFacturaMedicamento.PrecoUnitario;
                    facturaMedicamento.PrecoTotal = updateFacturaMedicamento.PrecoTotal;
                    facturaMedicamento.status = updateFacturaMedicamento.status;

                    _context.FacturasMedicamentos.Update(facturaMedicamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.FacturasMedicamentos
                        .Where(fm => fm.status)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FacturaMedicamento>>> InactivateFacturaMedicamento(int id)
        {
            var serviceResponse = new ServiceResponse<List<FacturaMedicamento>>();

            try
            {
                var facturaMedicamento = await _context.FacturasMedicamentos
                    .FirstOrDefaultAsync(fm => fm.FacturaMedicamentoID == id);

                if (facturaMedicamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "FacturaMedicamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    facturaMedicamento.status = false;
                    _context.FacturasMedicamentos.Update(facturaMedicamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.FacturasMedicamentos
                        .Where(fm => fm.status)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FacturaMedicamento>>> ActivateFacturaMedicamento(int id)
        {
            var serviceResponse = new ServiceResponse<List<FacturaMedicamento>>();

            try
            {
                var facturaMedicamento = await _context.FacturasMedicamentos
                    .FirstOrDefaultAsync(fm => fm.FacturaMedicamentoID == id);

                if (facturaMedicamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "FacturaMedicamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    facturaMedicamento.status = true;
                    _context.FacturasMedicamentos.Update(facturaMedicamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.FacturasMedicamentos
                        .Where(fm => fm.status)
                        .ToListAsync();
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
