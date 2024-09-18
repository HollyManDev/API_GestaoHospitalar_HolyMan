using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.MedicoServices
{
    public class MedicoService : MedicoInterface
    {
        private readonly ApplicationDbContext _context;

        public MedicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Medico>>> GetMedicos()
        {
            var serviceResponse = new ServiceResponse<List<Medico>>();

            try
            {
                serviceResponse.Data = await _context.Medicos
                    .Include(m => m.Especialidade)
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

        public async Task<ServiceResponse<Medico>> FindMedico(int id)
        {
            var serviceResponse = new ServiceResponse<Medico>();

            try
            {
                var medico = await _context.Medicos
                    .Include(m => m.Especialidade)
                    .FirstOrDefaultAsync(m => m.MedicoID == id);

                if (medico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Medico not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = medico;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Medico>>> CreateMedico(MedicoView newMedico)
        {
            var serviceResponse = new ServiceResponse<List<Medico>>();

            try
            {
                var medico = new Medico
                {
                    Nome = newMedico.Nome,
                    EspecialidadeID = newMedico.EspecialidadeID,
                    Telefone = newMedico.Telefone,
                    Email = newMedico.Email,
                    Endereco = newMedico.Endereco,
                    Certificacoes = newMedico.Certificacoes,
                    HorarioTrabalho = newMedico.HorarioTrabalho,
                    Status = newMedico.Status,
                };

                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Medicos
                    .Include(m => m.Especialidade)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Medico>>> UpdateMedico(MedicoView updateMedico)
        {
            var serviceResponse = new ServiceResponse<List<Medico>>();

            try
            {
                var medico = await _context.Medicos
                    .Include(m => m.Especialidade)
                    .FirstOrDefaultAsync(m => m.MedicoID == updateMedico.MedicoID);

                if (medico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Medico not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    medico.Nome = updateMedico.Nome;
                    medico.EspecialidadeID = updateMedico.EspecialidadeID;
                    medico.Telefone = updateMedico.Telefone;
                    medico.Email = updateMedico.Email;
                    medico.Endereco = updateMedico.Endereco;
                    medico.Certificacoes = updateMedico.Certificacoes;
                    medico.HorarioTrabalho = updateMedico.HorarioTrabalho;
                    medico.Status  = updateMedico.Status;

                    _context.Medicos.Update(medico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Medicos
                        .Include(m => m.Especialidade)
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

        public async Task<ServiceResponse<List<Medico>>> DeleteMedico(int id)
        {
            var serviceResponse = new ServiceResponse<List<Medico>>();

            try
            {
                var medico = await _context.Medicos
                    .FirstOrDefaultAsync(m => m.MedicoID == id);

                if (medico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Medico not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    medico.Status = false;
                    _context.Medicos.Update(medico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Medicos
                        .Include(m => m.Especialidade)
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
