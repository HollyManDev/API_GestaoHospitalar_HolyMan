using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.PacienteServices
{
    public class PacienteService : PacienteInterface
    {
        private readonly ApplicationDbContext _context;

        public PacienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Paciente>>> GetPacientes()
        {
            var serviceResponse = new ServiceResponse<List<Paciente>>();

            try
            {
                serviceResponse.Data = await _context.Pacientes.ToListAsync();
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

        public async Task<ServiceResponse<Paciente>> FindPaciente(int id)
        {
            var serviceResponse = new ServiceResponse<Paciente>();

            try
            {
                var paciente = await _context.Pacientes
                    .Include(p => p.Leito) // Incluindo o Leito relacionado
                    .FirstOrDefaultAsync(p => p.PacienteID == id);

                if (paciente == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Paciente not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = paciente;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Paciente>>> CreatePaciente(PacienteView newPaciente)
        {
            var serviceResponse = new ServiceResponse<List<Paciente>>();

            try
            {
                var paciente = new Paciente
                {
                    Nome = newPaciente.Nome,
                    DataNascimento = newPaciente.DataNascimento,
                    Sexo = newPaciente.Sexo,
                    Endereco = newPaciente.Endereco,
                    Telefone = newPaciente.Telefone,
                    Email = newPaciente.Email,
                    BI = newPaciente.BI,
                    Fotografia = newPaciente.Fotografia,
                    ContatoEmergenciaNome = newPaciente.ContatoEmergenciaNome,
                    ContatoEmergenciaTelefone = newPaciente.ContatoEmergenciaTelefone,
                    ContatoEmergenciaRelacao = newPaciente.ContatoEmergenciaRelacao,
                    HistoricoMedico = newPaciente.HistoricoMedico,
                    Seguro = newPaciente.Seguro,
                    Status = newPaciente.Status,
                    LeitoID = newPaciente.Leito // Opcional
                };

                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Pacientes.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Paciente>>> UpdatePaciente(PacienteView updatePaciente)
        {
            var serviceResponse = new ServiceResponse<List<Paciente>>();

            try
            {
                var paciente = await _context.Pacientes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.PacienteID == updatePaciente.PacienteID);

                if (paciente == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Paciente not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    paciente.Nome = updatePaciente.Nome;
                    paciente.DataNascimento = updatePaciente.DataNascimento;
                    paciente.Sexo = updatePaciente.Sexo;
                    paciente.Endereco = updatePaciente.Endereco;
                    paciente.Telefone = updatePaciente.Telefone;
                    paciente.Email = updatePaciente.Email;
                    paciente.BI = updatePaciente.BI;
                    paciente.Fotografia = updatePaciente.Fotografia;
                    paciente.ContatoEmergenciaNome = updatePaciente.ContatoEmergenciaNome;
                    paciente.ContatoEmergenciaTelefone = updatePaciente.ContatoEmergenciaTelefone;
                    paciente.ContatoEmergenciaRelacao = updatePaciente.ContatoEmergenciaRelacao;
                    paciente.HistoricoMedico = updatePaciente.HistoricoMedico;
                    paciente.Seguro = updatePaciente.Seguro;
                    paciente.Status = updatePaciente.Status;
                    paciente.LeitoID = updatePaciente.Leito; // Opcional

                    _context.Pacientes.Update(paciente);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Pacientes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Paciente>>> InactivatePaciente(int id)
        {
            var serviceResponse = new ServiceResponse<List<Paciente>>();

            try
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.PacienteID == id);

                if (paciente == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Paciente not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    paciente.Status = false; // Assumindo que você tem um campo de Status
                    _context.Pacientes.Update(paciente);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Pacientes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Paciente>>> ActivatePaciente(int id)
        {
            var serviceResponse = new ServiceResponse<List<Paciente>>();

            try
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.PacienteID == id);

                if (paciente == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Paciente not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    paciente.Status = true; // Assumindo que você tem um campo de Status
                    _context.Pacientes.Update(paciente);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Pacientes.ToListAsync();
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
