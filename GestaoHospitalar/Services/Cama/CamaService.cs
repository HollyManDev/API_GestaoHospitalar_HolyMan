using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.CamaServices
{
    public class CamaService : CamaInterface
    {
        private readonly ApplicationDbContext _context;

        public CamaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Cama>>> GetCamas()
        {
            var serviceResponse = new ServiceResponse<List<Cama>>();

            try
            {
                serviceResponse.Data = await _context.Camas.ToListAsync();

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

        public async Task<ServiceResponse<Cama>> FindCama(int id)
        {
            var serviceResponse = new ServiceResponse<Cama>();

            try
            {
                var cama = await _context.Camas.FirstOrDefaultAsync(c => c.CamaID == id);

                if (cama == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Cama not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = cama;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Cama>>> CreateCama(CamaView newCama)
        {
            var serviceResponse = new ServiceResponse<List<Cama>>();

            try
            {
                var cama = new Cama
                {
                    LeitoID = newCama.LeitoID,
                    Descricao = newCama.Descricao,
                    Status = newCama.Status
                };

                _context.Camas.Add(cama);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Camas.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Cama>>> UpdateCama(CamaView updateCama)
        {
            var serviceResponse = new ServiceResponse<List<Cama>>();

            try
            {
                var cama = await _context.Camas.FirstOrDefaultAsync(c => c.CamaID == updateCama.CamaID);

                if (cama == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Cama not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    cama.LeitoID = updateCama.LeitoID;
                    cama.Descricao = updateCama.Descricao;
                    cama.Status = updateCama.Status;

                    _context.Camas.Update(cama);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Camas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Cama>>> DeleteCama(int id)
        {
            var serviceResponse = new ServiceResponse<List<Cama>>();

            try
            {
                var cama = await _context.Camas.FirstOrDefaultAsync(c => c.CamaID == id);

                if (cama == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Cama not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    cama.Status = false;
                    _context.Camas.Update(cama);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Camas.ToListAsync();
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
