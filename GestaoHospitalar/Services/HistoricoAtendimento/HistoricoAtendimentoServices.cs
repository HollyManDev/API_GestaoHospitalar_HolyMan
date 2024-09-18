using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.HistoricoAtendimentoServices
{
    public class HistoricoAtendimentoService : HistoricoAtendimentoInterface
    {
        private readonly ApplicationDbContext _context;

        public HistoricoAtendimentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<HistoricoAtendimento>>> GetHistoricosAtendimento()
        {
            var serviceResponse = new ServiceResponse<List<HistoricoAtendimento>>();

            try
            {
                serviceResponse.Data = await _context.HistoricoAtendimentos.ToListAsync();
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

        public async Task<ServiceResponse<HistoricoAtendimento>> FindHistoricoAtendimento(int id)
        {
            var serviceResponse = new ServiceResponse<HistoricoAtendimento>();

            try
            {
                var historico = await _context.HistoricoAtendimentos
                    .Include(h => h.Paciente) // Incluindo o Paciente relacionado
                    .FirstOrDefaultAsync(h => h.HistoricoID == id);

                if (historico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Historico Atendimento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = historico;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HistoricoAtendimento>>> CreateHistoricoAtendimento(HistoricoAtendimentoView newHistoricoAtendimento)
        {
            var serviceResponse = new ServiceResponse<List<HistoricoAtendimento>>();

            try
            {
                var historico = new HistoricoAtendimento
                {
                    PacienteID = newHistoricoAtendimento.PacienteID,
                    DataHora = newHistoricoAtendimento.DataHora,
                    Descricao = newHistoricoAtendimento.Descricao,
                    Status = newHistoricoAtendimento.Status
                };

                _context.HistoricoAtendimentos.Add(historico);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.HistoricoAtendimentos.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HistoricoAtendimento>>> UpdateHistoricoAtendimento(HistoricoAtendimentoView updateHistoricoAtendimento)
        {
            var serviceResponse = new ServiceResponse<List<HistoricoAtendimento>>();

            try
            {
                var historico = await _context.HistoricoAtendimentos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(h => h.HistoricoID == updateHistoricoAtendimento.HistoricoID);

                if (historico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Historico Atendimento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    historico.PacienteID = updateHistoricoAtendimento.PacienteID;
                    historico.DataHora = updateHistoricoAtendimento.DataHora;
                    historico.Descricao = updateHistoricoAtendimento.Descricao;
                    historico.Status = updateHistoricoAtendimento.Status;

                    _context.HistoricoAtendimentos.Update(historico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.HistoricoAtendimentos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HistoricoAtendimento>>> InactivateHistoricoAtendimento(int id)
        {
            var serviceResponse = new ServiceResponse<List<HistoricoAtendimento>>();

            try
            {
                var historico = await _context.HistoricoAtendimentos.FirstOrDefaultAsync(h => h.HistoricoID == id);

                if (historico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Historico Atendimento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    historico.Status = false; // Atualizar para inativo
                    _context.HistoricoAtendimentos.Update(historico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.HistoricoAtendimentos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HistoricoAtendimento>>> ActivateHistoricoAtendimento(int id)
        {
            var serviceResponse = new ServiceResponse<List<HistoricoAtendimento>>();

            try
            {
                var historico = await _context.HistoricoAtendimentos.FirstOrDefaultAsync(h => h.HistoricoID == id);

                if (historico == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Historico Atendimento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    historico.Status = true; // Atualizar para ativo
                    _context.HistoricoAtendimentos.Update(historico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.HistoricoAtendimentos.ToListAsync();
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
