using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.EspecialidadeServices
{
    public class EspecialidadeService : EspecialidadeInterface
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Especialidade>>> GetEspecialidades()
        {
            var serviceResponse = new ServiceResponse<List<Especialidade>>();

            try
            {
                serviceResponse.Data = await _context.Especialidades.ToListAsync();

                //serviceResponse.Data = await _context.Especialidades
                                 //  .Where(e => e.Status == true)
                                   //.ToListAsync();

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

        public async Task<ServiceResponse<Especialidade>> FindEspecialidade(int id)
        {
            var serviceResponse = new ServiceResponse<Especialidade>();

            try
            {
                var especialidade = await _context.Especialidades.FirstOrDefaultAsync(e => e.EspecialidadeID == id);

                if (especialidade == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Especialidade not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = especialidade;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Especialidade>>> CreateEspecialidade(EspecialidadeView newEspecialidade)
        {
            var serviceResponse = new ServiceResponse<List<Especialidade>>();

            try
            {
                var especialidade = new Especialidade
                {
                    Nome = newEspecialidade.Nome,
                    Descricao = newEspecialidade.Descricao,
                    Status = newEspecialidade.Status
                };

                _context.Especialidades.Add(especialidade);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Especialidades.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Especialidade>>> UpdateEspecialidade(EspecialidadeView updateEspecialidade)
        {
            var serviceResponse = new ServiceResponse<List<Especialidade>>();

            try
            {
                var especialidade = await _context.Especialidades.FirstOrDefaultAsync(e => e.EspecialidadeID == updateEspecialidade.EspecialidadeID);

                if (especialidade == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Especialidade not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    especialidade.Nome = updateEspecialidade.Nome;
                    especialidade.Descricao = updateEspecialidade.Descricao;

                    _context.Especialidades.Update(especialidade);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Especialidades.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Especialidade>>> DeleteEspecialidade(int id)
        {
            var serviceResponse = new ServiceResponse<List<Especialidade>>();

            try
            {
                var especialidade = await _context.Especialidades.FirstOrDefaultAsync(e => e.EspecialidadeID == id);

                if (especialidade == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Especialidade not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    especialidade.Status = false;
                    _context.Especialidades.Update(especialidade);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Especialidades.ToListAsync();
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
