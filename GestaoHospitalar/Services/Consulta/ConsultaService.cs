using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ConsultaServices
{
    public class ConsultaService : ConsultaInterface
    {
        private readonly ApplicationDbContext _context;

        public ConsultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Consulta>>> GetConsultas()
        {
            var serviceResponse = new ServiceResponse<List<Consulta>>();

            try
            {
                serviceResponse.Data = await _context.Consultas.ToListAsync();
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

        public async Task<ServiceResponse<Consulta>> FindConsulta(int id)
        {
            var serviceResponse = new ServiceResponse<Consulta>();

            try
            {
                var consulta = await _context.Consultas
                    .Include(c => c.Paciente)
                    .Include(c => c.Medico)
                    .FirstOrDefaultAsync(c => c.ConsultaID == id);

                if (consulta == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Consulta not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = consulta;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Consulta>>> CreateConsulta(ConsultaView newConsulta)
        {
            var serviceResponse = new ServiceResponse<List<Consulta>>();

            try
            {
                var consulta = new Consulta
                {
                    PacienteID = newConsulta.PacienteID,
                    MedicoID = newConsulta.MedicoID,
                    DataHora = newConsulta.DataHora,
                    Motivo = newConsulta.Motivo,
                    Observacoes = newConsulta.Observacoes,
                    Status = newConsulta.Status,
                    Diagnostico = newConsulta.Diagnostico,
                    TratamentoRecomendado = newConsulta.TratamentoRecomendado
                };

                _context.Consultas.Add(consulta);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Consultas.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Consulta>>> UpdateConsulta(ConsultaView updateConsulta)
        {
            var serviceResponse = new ServiceResponse<List<Consulta>>();

            try
            {
                var consulta = await _context.Consultas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.ConsultaID == updateConsulta.ConsultaID);

                if (consulta == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Consulta not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    consulta.PacienteID = updateConsulta.PacienteID;
                    consulta.MedicoID = updateConsulta.MedicoID;
                    consulta.DataHora = updateConsulta.DataHora;
                    consulta.Motivo = updateConsulta.Motivo;
                    consulta.Observacoes = updateConsulta.Observacoes;
                    consulta.Status = updateConsulta.Status;
                    consulta.Diagnostico = updateConsulta.Diagnostico;
                    consulta.TratamentoRecomendado = updateConsulta.TratamentoRecomendado;

                    _context.Consultas.Update(consulta);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Consultas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Consulta>>> InactivateConsulta(int id)
        {
            var serviceResponse = new ServiceResponse<List<Consulta>>();

            try
            {
                var consulta = await _context.Consultas.FirstOrDefaultAsync(c => c.ConsultaID == id);

                if (consulta == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Consulta not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    consulta.Status = "Cancelado"; // Atualizar para um status representando inatividade
                    _context.Consultas.Update(consulta);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Consultas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Consulta>>> ActivateConsulta(int id)
        {
            var serviceResponse = new ServiceResponse<List<Consulta>>();

            try
            {
                var consulta = await _context.Consultas.FirstOrDefaultAsync(c => c.ConsultaID == id);

                if (consulta == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Consulta not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    consulta.Status = "Confirmado"; // Atualizar para um status representando ativação
                    _context.Consultas.Update(consulta);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Consultas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Consulta>>> GetConsultaByMedico(int medicoId)
        {
            var serviceResponse = new ServiceResponse<List<Consulta>>();

            try
            {
                var consultas = await _context.Consultas
                    .Where(a => a.MedicoID == medicoId)
                    .Include(a => a.Paciente) 
                    .Include(a => a.Medico)
                    .ToListAsync();

                if (!consultas.Any())
                {
                    serviceResponse.menssage = "No appointments found for this doctor!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = consultas;
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
