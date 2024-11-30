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
                // Criação do paciente
                var paciente = new Paciente
                {
                    Nome = newPaciente.Nome,
                    DataNascimento = newPaciente.DataNascimento,
                    Sexo = newPaciente.Sexo,
                    Endereco = newPaciente.Endereco,
                    Telefone = newPaciente.Telefone,
                    Email = newPaciente.Email,
                    Password ="paciente12",
                    BI = newPaciente.BI,
                    HistoricoMedico = newPaciente.HistoricoMedico, // Pode ser null
                    Seguro = newPaciente.Seguro, // Pode ser null
                    Status = newPaciente.Status,
                    LeitoID = newPaciente.Leito // Opcional
                };

                // Contatos de emergência são opcionais
                if (newPaciente.ContatosEmergencia != null && newPaciente.ContatosEmergencia.Count > 0)
                {
                    foreach (var contato in newPaciente.ContatosEmergencia)
                    {
                        paciente.ContatosEmergencia.Add(new ContatoEmergencia
                        {
                            ContatoEmergenciaNome = contato.ContatoEmergenciaNome,
                            ContatoEmergenciaTelefone = contato.ContatoEmergenciaTelefone,
                            ContatoEmergenciaRelacao = contato.ContatoEmergenciaRelacao
                        });
                    }
                }

                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Pacientes.Include(p => p.ContatosEmergencia).ToListAsync();
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
                // Buscar o paciente no banco de dados
                var paciente = await _context.Pacientes
                    .Include(p => p.ContatosEmergencia) // Incluindo contatos de emergência
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.PacienteID == updatePaciente.PacienteID);

                if (paciente == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Paciente não encontrado!";
                    serviceResponse.Success = false;
                }
                else
                {
                    // Atualizando os campos do paciente
                    paciente.Nome = updatePaciente.Nome;
                    paciente.DataNascimento = updatePaciente.DataNascimento;
                    paciente.Sexo = updatePaciente.Sexo;
                    paciente.Endereco = updatePaciente.Endereco;
                    paciente.Telefone = updatePaciente.Telefone;
                    paciente.Email = updatePaciente.Email;
                    paciente.BI = updatePaciente.BI;
                    paciente.HistoricoMedico = updatePaciente.HistoricoMedico;
                    paciente.Seguro = updatePaciente.Seguro;
                    paciente.Status = updatePaciente.Status;
                    paciente.LeitoID = updatePaciente.Leito; // Opcional

                    // Atualizando os contatos de emergência (se houver)
                    if (updatePaciente.ContatosEmergencia != null && updatePaciente.ContatosEmergencia.Count > 0)
                    {
                        // Primeiro, removendo os contatos de emergência antigos
                        _context.ContatoEmergencia.RemoveRange(paciente.ContatosEmergencia);

                        // Em seguida, adicionando os novos contatos
                        foreach (var contato in updatePaciente.ContatosEmergencia)
                        {
                            paciente.ContatosEmergencia.Add(new ContatoEmergencia
                            {
                                ContatoEmergenciaNome = contato.ContatoEmergenciaNome,
                                ContatoEmergenciaTelefone = contato.ContatoEmergenciaTelefone,
                                ContatoEmergenciaRelacao = contato.ContatoEmergenciaRelacao
                            });
                        }
                    }

                    // Atualizando o paciente no banco de dados
                    _context.Pacientes.Update(paciente);
                    await _context.SaveChangesAsync();

                    // Retornando todos os pacientes, incluindo os novos contatos de emergência
                    serviceResponse.Data = await _context.Pacientes.Include(p => p.ContatosEmergencia).ToListAsync();
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
