using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;


namespace GestaoHospitalar.Services.AgendamentoServices
{
    public class AgendamentoService : AgendamentoInterface
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Agendamento>>> GetAgendamentos()
        {
            var serviceResponse = new ServiceResponse<List<Agendamento>>();

            try
            {
                serviceResponse.Data = await _context.Agendamentos.ToListAsync();
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

        public async Task<ServiceResponse<Agendamento>> FindAgendamento(int id)
        {
            var serviceResponse = new ServiceResponse<Agendamento>();

            try
            {
                var agendamento = await _context.Agendamentos
                    .Include(a => a.Paciente)
                    .Include(a => a.Medico)
                    .FirstOrDefaultAsync(a => a.AgendamentoID == id);

                if (agendamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Agendamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = agendamento;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Agendamento>>> CreateAgendamento(AgendamentoView newAgendamento)
        {
            var serviceResponse = new ServiceResponse<List<Agendamento>>();

            try
            {
                var agendamento = new Agendamento
                {
                    PacienteID = newAgendamento.PacienteID,
                    MedicoID = newAgendamento.MedicoID,
                    DataHora = newAgendamento.DataHora,
                    TipoAgendamento = newAgendamento.TipoAgendamento,
                    Status = newAgendamento.Status,
                    Observacoes = newAgendamento.Observacoes,
                   
                };

                _context.Agendamentos.Add(agendamento);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Agendamentos.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Agendamento>>> UpdateAgendamento(AgendamentoView updateAgendamento)
        {
            var serviceResponse = new ServiceResponse<List<Agendamento>>();

            try
            {
                var agendamento = await _context.Agendamentos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.AgendamentoID == updateAgendamento.AgendamentoID);

                if (agendamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Agendamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    agendamento.PacienteID = updateAgendamento.PacienteID;
                    agendamento.MedicoID = updateAgendamento.MedicoID;
                    agendamento.DataHora = updateAgendamento.DataHora;
                    agendamento.TipoAgendamento = updateAgendamento.TipoAgendamento;
                    agendamento.Status = updateAgendamento.Status;
                    agendamento.Observacoes = updateAgendamento.Observacoes;
                   

                    _context.Agendamentos.Update(agendamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Agendamentos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Agendamento>>> InactivateAgendamento(int id)
        {
            var serviceResponse = new ServiceResponse<List<Agendamento>>();

            try
            {
                var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.AgendamentoID == id);

                if (agendamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Agendamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                   
                    _context.Agendamentos.Update(agendamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Agendamentos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Agendamento>>> ActivateAgendamento(int id)
        {
            var serviceResponse = new ServiceResponse<List<Agendamento>>();

            try
            {
                var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.AgendamentoID == id);

                if (agendamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Agendamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    
                    _context.Agendamentos.Update(agendamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Agendamentos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Agendamento>>> GetAgendamentosByMedico(int medicoId)
        {
            var serviceResponse = new ServiceResponse<List<Agendamento>>();

            try
            {
                var agendamentos = await _context.Agendamentos
                    .Where(a => a.MedicoID == medicoId)
                    .Include(a => a.Paciente) // Inclua relações necessárias
                    .Include(a => a.Medico)
                    .ToListAsync();

                if (!agendamentos.Any())
                {
                    serviceResponse.menssage = "No appointments found for this doctor!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = agendamentos;
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
