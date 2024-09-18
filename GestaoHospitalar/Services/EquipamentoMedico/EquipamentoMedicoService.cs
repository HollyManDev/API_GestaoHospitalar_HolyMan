using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.EquipamentoMedicoServices
{
    public class EquipamentoMedicoService : EquipamentoMedicoInterface
    {
        private readonly ApplicationDbContext _context;

        public EquipamentoMedicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<EquipamentoMedico>>> GetEquipamentosMedicos()
        {
            var serviceResponse = new ServiceResponse<List<EquipamentoMedico>>();

            try
            {
                serviceResponse.Data = await _context.EquipamentosMedicos.ToListAsync();
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

        public async Task<ServiceResponse<EquipamentoMedico>> FindEquipamentoMedico(int id)
        {
            var serviceResponse = new ServiceResponse<EquipamentoMedico>();

            try
            {
                var equipamentoMedico = await _context.EquipamentosMedicos
                    .FirstOrDefaultAsync(e => e.EquipamentoID == id);

                if (equipamentoMedico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Equipamento Médico not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = equipamentoMedico;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EquipamentoMedico>>> CreateEquipamentoMedico(EquipamentoMedicoView newEquipamentoMedico)
        {
            var serviceResponse = new ServiceResponse<List<EquipamentoMedico>>();

            try
            {
                var equipamentoMedico = new EquipamentoMedico
                {
                    Nome = newEquipamentoMedico.Nome,
                    DataAquisicao = newEquipamentoMedico.DataAquisicao,
                    Status = newEquipamentoMedico.Status,
                    Localizacao = newEquipamentoMedico.Localizacao,
                    Imagem = newEquipamentoMedico.Imagem // Incluindo a imagem
                };

                _context.EquipamentosMedicos.Add(equipamentoMedico);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.EquipamentosMedicos.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EquipamentoMedico>>> UpdateEquipamentoMedico(EquipamentoMedicoView updateEquipamentoMedico)
        {
            var serviceResponse = new ServiceResponse<List<EquipamentoMedico>>();

            try
            {
                var equipamentoMedico = await _context.EquipamentosMedicos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.EquipamentoID == updateEquipamentoMedico.EquipamentoID);

                if (equipamentoMedico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Equipamento Médico not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    equipamentoMedico.Nome = updateEquipamentoMedico.Nome;
                    equipamentoMedico.DataAquisicao = updateEquipamentoMedico.DataAquisicao;
                    equipamentoMedico.Status = updateEquipamentoMedico.Status;
                    equipamentoMedico.Localizacao = updateEquipamentoMedico.Localizacao;
                    equipamentoMedico.Imagem = updateEquipamentoMedico.Imagem; // Atualizando a imagem

                    _context.EquipamentosMedicos.Update(equipamentoMedico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.EquipamentosMedicos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EquipamentoMedico>>> InactivateEquipamentoMedico(int id)
        {
            var serviceResponse = new ServiceResponse<List<EquipamentoMedico>>();

            try
            {
                var equipamentoMedico = await _context.EquipamentosMedicos.FirstOrDefaultAsync(e => e.EquipamentoID == id);

                if (equipamentoMedico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Equipamento Médico not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    equipamentoMedico.Status = false; // Marcando como inativo
                    _context.EquipamentosMedicos.Update(equipamentoMedico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.EquipamentosMedicos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EquipamentoMedico>>> ActivateEquipamentoMedico(int id)
        {
            var serviceResponse = new ServiceResponse<List<EquipamentoMedico>>();

            try
            {
                var equipamentoMedico = await _context.EquipamentosMedicos.FirstOrDefaultAsync(e => e.EquipamentoID == id);

                if (equipamentoMedico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Equipamento Médico not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    equipamentoMedico.Status = true; // Marcando como ativo
                    _context.EquipamentosMedicos.Update(equipamentoMedico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.EquipamentosMedicos.ToListAsync();
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
