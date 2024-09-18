using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ReciboServices
{
    public class ReciboService : ReciboInterface
    {
        private readonly ApplicationDbContext _context;

        public ReciboService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Recibo>>> GetRecibos()
        {
            var serviceResponse = new ServiceResponse<List<Recibo>>();

            try
            {
                serviceResponse.Data = await _context.Recibos
                    .Include(r => r.Factura) // Incluindo Factura relacionada
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

        public async Task<ServiceResponse<Recibo>> FindRecibo(int id)
        {
            var serviceResponse = new ServiceResponse<Recibo>();

            try
            {
                var recibo = await _context.Recibos
                    .Include(r => r.Factura) // Incluindo Factura relacionada
                    .FirstOrDefaultAsync(r => r.ReciboID == id);

                if (recibo == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Recibo not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = recibo;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Recibo>>> CreateRecibo(ReciboView newRecibo)
        {
            var serviceResponse = new ServiceResponse<List<Recibo>>();

            try
            {
                var recibo = new Recibo
                {
                    FaturaID = newRecibo.FaturaID,
                    DataRecebimento = newRecibo.DataRecebimento,
                    Valor = newRecibo.Valor,
                    MetodoPagamento = newRecibo.MetodoPagamento,
                    Status = newRecibo.Status
                };

                _context.Recibos.Add(recibo);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Recibos.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Recibo>>> UpdateRecibo(ReciboView updateRecibo)
        {
            var serviceResponse = new ServiceResponse<List<Recibo>>();

            try
            {
                var recibo = await _context.Recibos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.ReciboID == updateRecibo.ReciboID);

                if (recibo == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Recibo not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    recibo.FaturaID = updateRecibo.FaturaID;
                    recibo.DataRecebimento = updateRecibo.DataRecebimento;
                    recibo.Valor = updateRecibo.Valor;
                    recibo.MetodoPagamento = updateRecibo.MetodoPagamento;
                    recibo.Status = updateRecibo.Status;

                    _context.Recibos.Update(recibo);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Recibos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Recibo>>> InactivateRecibo(int id)
        {
            var serviceResponse = new ServiceResponse<List<Recibo>>();

            try
            {
                var recibo = await _context.Recibos.FirstOrDefaultAsync(r => r.ReciboID == id);

                if (recibo == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Recibo not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    recibo.Status = false; // Atualiza o status para inativo
                    _context.Recibos.Update(recibo);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Recibos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Recibo>>> ActivateRecibo(int id)
        {
            var serviceResponse = new ServiceResponse<List<Recibo>>();

            try
            {
                var recibo = await _context.Recibos.FirstOrDefaultAsync(r => r.ReciboID == id);

                if (recibo == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Recibo not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    recibo.Status = true; // Atualiza o status para ativo
                    _context.Recibos.Update(recibo);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Recibos.ToListAsync();
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
