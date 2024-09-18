using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.PrescricaoServices
{
    public class PrescricaoService : PrescricaoInterface
    {
        private readonly ApplicationDbContext _context;

        public PrescricaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Prescricao>>> GetPrescricoes()
        {
            var serviceResponse = new ServiceResponse<List<Prescricao>>();

            try
            {
                serviceResponse.Data = await _context.Prescricoes.ToListAsync();
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

        public async Task<ServiceResponse<Prescricao>> FindPrescricao(int id)
        {
            var serviceResponse = new ServiceResponse<Prescricao>();

            try
            {
                var prescricao = await _context.Prescricoes
                    .Include(p => p.Consulta) // Incluindo o Consulta relacionado
                    .FirstOrDefaultAsync(p => p.PrescricaoID == id);

                if (prescricao == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Prescrição not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = prescricao;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Prescricao>>> CreatePrescricao(PrecricaoView newPrescricao)
        {
            var serviceResponse = new ServiceResponse<List<Prescricao>>();

            try
            {
                var prescricao = new Prescricao
                {
                    ConsultaID = newPrescricao.ConsultaID,
                    Medicamento = newPrescricao.Medicamento,
                    Dosagem = newPrescricao.Dosagem,
                    Frequencia = newPrescricao.Frequencia,
                    Duracao = newPrescricao.Duracao,
                    InstrucoesUso = newPrescricao.InstrucoesUso,
                    DataPrescricao = newPrescricao.DataPrescricao,
                    Status = newPrescricao.Status
                };

                _context.Prescricoes.Add(prescricao);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Prescricoes.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Prescricao>>> UpdatePrescricao(PrecricaoView updatePrescricao)
        {
            var serviceResponse = new ServiceResponse<List<Prescricao>>();

            try
            {
                var prescricao = await _context.Prescricoes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.PrescricaoID == updatePrescricao.PrescricaoID);

                if (prescricao == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Prescrição not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    prescricao.ConsultaID = updatePrescricao.ConsultaID;
                    prescricao.Medicamento = updatePrescricao.Medicamento;
                    prescricao.Dosagem = updatePrescricao.Dosagem;
                    prescricao.Frequencia = updatePrescricao.Frequencia;
                    prescricao.Duracao = updatePrescricao.Duracao;
                    prescricao.InstrucoesUso = updatePrescricao.InstrucoesUso;
                    prescricao.DataPrescricao = updatePrescricao.DataPrescricao;
                    prescricao.Status = updatePrescricao.Status;

                    _context.Prescricoes.Update(prescricao);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Prescricoes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Prescricao>>> InactivatePrescricao(int id)
        {
            var serviceResponse = new ServiceResponse<List<Prescricao>>();

            try
            {
                var prescricao = await _context.Prescricoes.FirstOrDefaultAsync(p => p.PrescricaoID == id);

                if (prescricao == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Prescrição not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    prescricao.Status = false; // Atualizar para inativo
                    _context.Prescricoes.Update(prescricao);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Prescricoes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Prescricao>>> ActivatePrescricao(int id)
        {
            var serviceResponse = new ServiceResponse<List<Prescricao>>();

            try
            {
                var prescricao = await _context.Prescricoes.FirstOrDefaultAsync(p => p.PrescricaoID == id);

                if (prescricao == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Prescrição not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    prescricao.Status = true; // Atualizar para ativo
                    _context.Prescricoes.Update(prescricao);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Prescricoes.ToListAsync();
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
