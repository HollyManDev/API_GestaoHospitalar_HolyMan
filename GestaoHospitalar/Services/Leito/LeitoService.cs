using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.LeitoServices
{
    public class LeitoService : LeitoInterface
    {
        private readonly ApplicationDbContext _context;

        public LeitoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Leito>>> GetLeitos()
        {
            var serviceResponse = new ServiceResponse<List<Leito>>();

            try
            {
                serviceResponse.Data = await _context.Leitos.ToListAsync();

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

        public async Task<ServiceResponse<Leito>> FindLeito(int id)
        {
            var serviceResponse = new ServiceResponse<Leito>();

            try
            {
                var leito = await _context.Leitos.FirstOrDefaultAsync(l => l.LeitoID == id);

                if (leito == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Leito not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = leito;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Leito>>> CreateLeito(LeitoView newLeito)
        {
            var serviceResponse = new ServiceResponse<List<Leito>>();

            try
            {
                var leito = new Leito
                {
                    NumeroLeito = newLeito.NumeroLeito,
                    Status = newLeito.Status
                };

                _context.Leitos.Add(leito);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Leitos.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Leito>>> UpdateLeito(LeitoView updateLeito)
        {
            var serviceResponse = new ServiceResponse<List<Leito>>();

            try
            {
                var leito = await _context.Leitos.FirstOrDefaultAsync(l => l.LeitoID == updateLeito.LeitoID);

                if (leito == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Leito not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    leito.NumeroLeito = updateLeito.NumeroLeito;
                    leito.Status = updateLeito.Status;

                    _context.Leitos.Update(leito);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Leitos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Leito>>> DeleteLeito(int id)
        {
            var serviceResponse = new ServiceResponse<List<Leito>>();

            try
            {
                var leito = await _context.Leitos.FirstOrDefaultAsync(l => l.LeitoID == id);

                if (leito == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Leito not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    leito.Status = false;
                    _context.Leitos.Update(leito);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Leitos.ToListAsync();
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
