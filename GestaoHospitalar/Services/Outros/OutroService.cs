using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.OutroServices
{
    public class OutroService : OutroInterface
    {
        private readonly ApplicationDbContext _context;

        public OutroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Outro>>> GetOutros()
        {
            var serviceResponse = new ServiceResponse<List<Outro>>();

            try
            {
                serviceResponse.Data = await _context.Outros.ToListAsync();

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

        public async Task<ServiceResponse<Outro>> FindOutro(int id)
        {
            var serviceResponse = new ServiceResponse<Outro>();

            try
            {
                var outro = await _context.Outros.FirstOrDefaultAsync(o => o.Id == id);

                if (outro == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Outro not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = outro;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Outro>>> CreateOutro(OutroView newOutro)
        {
            var serviceResponse = new ServiceResponse<List<Outro>>();

            try
            {
                var outro = new Outro
                {
                    Nome = newOutro.Nome,
                    Type = newOutro.Type,
                    Status = newOutro.Status
                };

                _context.Outros.Add(outro);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Outros.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Outro>>> UpdateOutro(OutroView updateOutro)
        {
            var serviceResponse = new ServiceResponse<List<Outro>>();

            try
            {
                var outro = await _context.Outros.FirstOrDefaultAsync(o => o.Id == updateOutro.Id);

                if (outro == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Outro not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    outro.Nome = updateOutro.Nome;
                    outro.Type = updateOutro.Type;
                    outro.Status = updateOutro.Status;

                    _context.Outros.Update(outro);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Outros.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Outro>>> DeleteOutro(int id)
        {
            var serviceResponse = new ServiceResponse<List<Outro>>();

            try
            {
                var outro = await _context.Outros.FirstOrDefaultAsync(o => o.Id == id);

                if (outro == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Outro not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    outro.Status = false;
                    _context.Outros.Update(outro);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Outros.ToListAsync();
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
