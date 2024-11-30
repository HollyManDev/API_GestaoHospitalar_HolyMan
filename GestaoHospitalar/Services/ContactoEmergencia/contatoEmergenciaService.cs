using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using GestaoHospitalar.Services.ContactoEmergencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.ContatoEmergenciaServices
{
    public class ContatoEmergenciaService : contatoEmergenciaInterface
    {
        private readonly ApplicationDbContext _context;

        public ContatoEmergenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para listar todos os contatos de emergência
        public async Task<ServiceResponse<List<ContatoEmergencia>>> GetContatosEmergencia()
        {
            var serviceResponse = new ServiceResponse<List<ContatoEmergencia>>();

            try
            {
                serviceResponse.Data = await _context.ContatoEmergencia.ToListAsync();
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

        // Método para encontrar um contato de emergência específico pelo ID
        public async Task<ServiceResponse<ContatoEmergencia>> FindContatoEmergencia(int id)
        {
            var serviceResponse = new ServiceResponse<ContatoEmergencia>();

            try
            {
                var contato = await _context.ContatoEmergencia.FirstOrDefaultAsync(c => c.ContatoEmergenciaID == id);

                if (contato == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Contato de emergência não encontrado!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = contato;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        // Método para criar um novo contato de emergência
        public async Task<ServiceResponse<List<ContatoEmergencia>>> CreateContatoEmergencia(ContatoEmergenciaView newContatoEmergencia)
        {
            var serviceResponse = new ServiceResponse<List<ContatoEmergencia>>();

            try
            {
                var contato = new ContatoEmergencia
                {
                    ContatoEmergenciaNome = newContatoEmergencia.ContatoEmergenciaNome,
                    ContatoEmergenciaTelefone = newContatoEmergencia.ContatoEmergenciaTelefone,
                    ContatoEmergenciaRelacao = newContatoEmergencia.ContatoEmergenciaRelacao,
                    PacienteID = newContatoEmergencia.PacienteID
                };

                _context.ContatoEmergencia.Add(contato);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.ContatoEmergencia.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        // Método para atualizar um contato de emergência existente
        public async Task<ServiceResponse<List<ContatoEmergencia>>> UpdateContatoEmergencia(ContatoEmergenciaView updateContatoEmergencia)
        {
            var serviceResponse = new ServiceResponse<List<ContatoEmergencia>>();

            try
            {
                var contato = await _context.ContatoEmergencia
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.ContatoEmergenciaID == updateContatoEmergencia.ContatoEmergenciaID);

                if (contato == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Contato de emergência não encontrado!";
                    serviceResponse.Success = false;
                }
                else
                {
                    contato.ContatoEmergenciaNome = updateContatoEmergencia.ContatoEmergenciaNome;
                    contato.ContatoEmergenciaTelefone = updateContatoEmergencia.ContatoEmergenciaTelefone;
                    contato.ContatoEmergenciaRelacao = updateContatoEmergencia.ContatoEmergenciaRelacao;
                    contato.PacienteID = updateContatoEmergencia.PacienteID;

                    _context.ContatoEmergencia.Update(contato);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.ContatoEmergencia.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        // Método para excluir um contato de emergência
        public async Task<ServiceResponse<List<ContatoEmergencia>>> DeleteContatoEmergencia(int id)
        {
            var serviceResponse = new ServiceResponse<List<ContatoEmergencia>>();

            try
            {
                var contato = await _context.ContatoEmergencia.FirstOrDefaultAsync(c => c.ContatoEmergenciaID == id);

                if (contato == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Contato de emergência não encontrado!";
                    serviceResponse.Success = false;
                }
                else
                {
                    _context.ContatoEmergencia.Remove(contato);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.ContatoEmergencia.ToListAsync();
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
