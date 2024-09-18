using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ResultadoExameServices
{
    public class ResultadoExameService : ResultadoExameInterface
    {
        private readonly ApplicationDbContext _context;

        public ResultadoExameService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ResultadoExame>>> GetResultadosExames()
        {
            var serviceResponse = new ServiceResponse<List<ResultadoExame>>();

            try
            {
                serviceResponse.Data = await _context.ResultadosExames
                    .Include(re => re.Exame) // Incluindo Exame relacionado
                    .Include(re => re.Paciente) // Incluindo Paciente relacionado
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

        public async Task<ServiceResponse<ResultadoExame>> FindResultadoExame(int id)
        {
            var serviceResponse = new ServiceResponse<ResultadoExame>();

            try
            {
                var resultadoExame = await _context.ResultadosExames
                    .Include(re => re.Exame) // Incluindo Exame relacionado
                    .Include(re => re.Paciente) // Incluindo Paciente relacionado
                    .FirstOrDefaultAsync(re => re.ResultadoExameID == id);

                if (resultadoExame == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "ResultadoExame not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = resultadoExame;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ResultadoExame>>> CreateResultadoExame(ResultadoExameView newResultadoExame)
        {
            var serviceResponse = new ServiceResponse<List<ResultadoExame>>();

            try
            {
                var resultadoExame = new ResultadoExame
                {
                    ExameID = newResultadoExame.ExameID,
                    PacienteID = newResultadoExame.PacienteID,
                    Data = newResultadoExame.Data,
                    Resultado = newResultadoExame.Resultado,
                    Observacoes = newResultadoExame.Observacoes,
                    ValoresReferencia = newResultadoExame.ValoresReferencia,
                    InterpretacaoMedica = newResultadoExame.InterpretacaoMedica,
                    Status = newResultadoExame.Status
                };

                _context.ResultadosExames.Add(resultadoExame);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.ResultadosExames.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ResultadoExame>>> UpdateResultadoExame(ResultadoExameView updateResultadoExame)
        {
            var serviceResponse = new ServiceResponse<List<ResultadoExame>>();

            try
            {
                var resultadoExame = await _context.ResultadosExames
                    .AsNoTracking()
                    .FirstOrDefaultAsync(re => re.ResultadoExameID == updateResultadoExame.ResultadoExameID);

                if (resultadoExame == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "ResultadoExame not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    resultadoExame.ExameID = updateResultadoExame.ExameID;
                    resultadoExame.PacienteID = updateResultadoExame.PacienteID;
                    resultadoExame.Data = updateResultadoExame.Data;
                    resultadoExame.Resultado = updateResultadoExame.Resultado;
                    resultadoExame.Observacoes = updateResultadoExame.Observacoes;
                    resultadoExame.ValoresReferencia = updateResultadoExame.ValoresReferencia;
                    resultadoExame.InterpretacaoMedica = updateResultadoExame.InterpretacaoMedica;
                    resultadoExame.Status = updateResultadoExame.Status;

                    _context.ResultadosExames.Update(resultadoExame);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.ResultadosExames.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ResultadoExame>>> InactivateResultadoExame(int id)
        {
            var serviceResponse = new ServiceResponse<List<ResultadoExame>>();

            try
            {
                var resultadoExame = await _context.ResultadosExames.FirstOrDefaultAsync(re => re.ResultadoExameID == id);

                if (resultadoExame == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "ResultadoExame not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    resultadoExame.Status = false; // Atualiza o status para inativo
                    _context.ResultadosExames.Update(resultadoExame);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.ResultadosExames.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ResultadoExame>>> ActivateResultadoExame(int id)
        {
            var serviceResponse = new ServiceResponse<List<ResultadoExame>>();

            try
            {
                var resultadoExame = await _context.ResultadosExames.FirstOrDefaultAsync(re => re.ResultadoExameID == id);

                if (resultadoExame == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "ResultadoExame not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    resultadoExame.Status = true; // Atualiza o status para ativo
                    _context.ResultadosExames.Update(resultadoExame);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.ResultadosExames.ToListAsync();
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
