using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.FacturaServices
{
    public class FacturaService : FacturaInterface
    {
        private readonly ApplicationDbContext _context;

        public FacturaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Factura>>> GetFacturas()
        {
            var serviceResponse = new ServiceResponse<List<Factura>>();

            try
            {
                serviceResponse.Data = await _context.Faturas
                    .Include(f => f.Paciente) // Incluindo Paciente relacionado
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

        public async Task<ServiceResponse<Factura>> FindFactura(int id)
        {
            var serviceResponse = new ServiceResponse<Factura>();

            try
            {
                var factura = await _context.Faturas
                    .Include(f => f.Paciente) // Incluindo Paciente relacionado
                    .FirstOrDefaultAsync(f => f.FaturaID == id);

                if (factura == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Factura not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = factura;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Factura>>> CreateFactura(FacturaView newFactura)
        {
            var serviceResponse = new ServiceResponse<List<Factura>>();

            try
            {
                var factura = new Factura
                {
                    PacienteID = newFactura.PacienteID,
                    Valor = newFactura.Valor,
                    DataEmissao = newFactura.DataEmissao,
                    DataVencimento = newFactura.DataVencimento,
                    Status = newFactura.Status,
                    StatusExist = newFactura.StatusExist,
                    FormaPagamento = newFactura.FormaPagamento
                };

                _context.Faturas.Add(factura);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Faturas.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Factura>>> UpdateFactura(FacturaView updateFactura)
        {
            var serviceResponse = new ServiceResponse<List<Factura>>();

            try
            {
                var factura = await _context.Faturas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(f => f.FaturaID == updateFactura.FaturaID);

                if (factura == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Factura not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    factura.PacienteID = updateFactura.PacienteID;
                    factura.Valor = updateFactura.Valor;
                    factura.DataEmissao = updateFactura.DataEmissao;
                    factura.DataVencimento = updateFactura.DataVencimento;
                    factura.Status = updateFactura.Status;
                    factura.StatusExist = updateFactura.StatusExist;
                    factura.FormaPagamento = updateFactura.FormaPagamento;

                    _context.Faturas.Update(factura);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Faturas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Factura>>> InactivateFactura(int id)
        {
            var serviceResponse = new ServiceResponse<List<Factura>>();

            try
            {
                var factura = await _context.Faturas.FirstOrDefaultAsync(f => f.FaturaID == id);

                if (factura == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Factura not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    factura.StatusExist = false; // Atualiza o status para inativo
                    _context.Faturas.Update(factura);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Faturas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Factura>>> ActivateFactura(int id)
        {
            var serviceResponse = new ServiceResponse<List<Factura>>();

            try
            {
                var factura = await _context.Faturas.FirstOrDefaultAsync(f => f.FaturaID == id);

                if (factura == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Factura not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    factura.StatusExist = true; // Atualiza o status para ativo
                    _context.Faturas.Update(factura);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Faturas.ToListAsync();
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
