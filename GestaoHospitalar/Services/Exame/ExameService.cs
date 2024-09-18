using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ExameServices
{
    public class ExameService : ExameInterface
    {
        private readonly ApplicationDbContext _context;

        public ExameService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Exame>>> GetExames()
        {
            var serviceResponse = new ServiceResponse<List<Exame>>();

            try
            {
                serviceResponse.Data = await _context.Exames
                    .Include(e => e.ResultadosExames) // Incluindo ResultadosExames relacionados, se necessário
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

        public async Task<ServiceResponse<Exame>> FindExame(int id)
        {
            var serviceResponse = new ServiceResponse<Exame>();

            try
            {
                var exame = await _context.Exames
                    .Include(e => e.ResultadosExames) // Incluindo ResultadosExames relacionados, se necessário
                    .FirstOrDefaultAsync(e => e.ExameID == id);

                if (exame == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Exame not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = exame;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Exame>>> CreateExame(ExameView newExame)
        {
            var serviceResponse = new ServiceResponse<List<Exame>>();

            try
            {
                var exame = new Exame
                {
                    Nome = newExame.Nome,
                    Descricao = newExame.Descricao,
                    Categoria = newExame.Categoria,
                    Preço = newExame.Preço,
                    Status = newExame.Status
                };

                _context.Exames.Add(exame);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Exames.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Exame>>> UpdateExame(ExameView updateExame)
        {
            var serviceResponse = new ServiceResponse<List<Exame>>();

            try
            {
                var exame = await _context.Exames
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.ExameID == updateExame.ExameID);

                if (exame == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Exame not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    exame.Nome = updateExame.Nome;
                    exame.Descricao = updateExame.Descricao;
                    exame.Categoria = updateExame.Categoria;
                    exame.Preço = updateExame.Preço;
                    exame.Status = updateExame.Status;

                    _context.Exames.Update(exame);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Exames.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Exame>>> InactivateExame(int id)
        {
            var serviceResponse = new ServiceResponse<List<Exame>>();

            try
            {
                var exame = await _context.Exames.FirstOrDefaultAsync(e => e.ExameID == id);

                if (exame == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Exame not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    exame.Status = false; // Atualiza o status para inativo
                    _context.Exames.Update(exame);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Exames.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Exame>>> ActivateExame(int id)
        {
            var serviceResponse = new ServiceResponse<List<Exame>>();

            try
            {
                var exame = await _context.Exames.FirstOrDefaultAsync(e => e.ExameID == id);

                if (exame == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Exame not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    exame.Status = true; // Atualiza o status para ativo
                    _context.Exames.Update(exame);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Exames.ToListAsync();
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
