using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.TelefoneFuncionarioServices
{
    public class TelefoneFuncionarioService : TelefoneFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;

        public TelefoneFuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TelefoneFuncionario>>> GetTelefonesFuncionarios()
        {
            ServiceResponse<List<TelefoneFuncionario>> serviceResponse = new ServiceResponse<List<TelefoneFuncionario>>();
            try
            {
                serviceResponse.Data = await _context.TelefoneFuncionario.ToListAsync();
                if (!serviceResponse.Data.Any())
                {
                    serviceResponse.menssage = "No TelefoneFuncionario found!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TelefoneFuncionario>> FindTelefoneFuncionario(int id)
        {
            ServiceResponse<TelefoneFuncionario> serviceResponse = new ServiceResponse<TelefoneFuncionario>();
            try
            {
                var telefoneFuncionario = await _context.TelefoneFuncionario.FindAsync(id);
                if (telefoneFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "TelefoneFuncionario not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = telefoneFuncionario;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneFuncionario>>> CreateTelefoneFuncionario(TelefoneFuncionarioView newTelefoneFuncionarioView)
        {
            ServiceResponse<List<TelefoneFuncionario>> serviceResponse = new ServiceResponse<List<TelefoneFuncionario>>();

            try
            {
                // Converte o TelefoneFuncionarioView em uma entidade TelefoneFuncionario
                var telefoneFuncionario = new TelefoneFuncionario
                {
                    Telefone = newTelefoneFuncionarioView.Telefone,
                    FuncionarioID = newTelefoneFuncionarioView.FuncionarioID
                };

                _context.TelefoneFuncionario.Add(telefoneFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.TelefoneFuncionario.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneFuncionario>>> UpdateTelefoneFuncionario(TelefoneFuncionarioView updatedTelefoneFuncionarioView)
        {
            ServiceResponse<List<TelefoneFuncionario>> serviceResponse = new ServiceResponse<List<TelefoneFuncionario>>();

            try
            {
                var telefoneFuncionario = await _context.TelefoneFuncionario.FindAsync(updatedTelefoneFuncionarioView.TelefoneID);

                if (telefoneFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "TelefoneFuncionario not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    // Atualizando os dados com base na view model recebida
                    telefoneFuncionario.Telefone = updatedTelefoneFuncionarioView.Telefone;
                    telefoneFuncionario.FuncionarioID = updatedTelefoneFuncionarioView.FuncionarioID;

                    _context.TelefoneFuncionario.Update(telefoneFuncionario);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = await _context.TelefoneFuncionario.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneFuncionario>>> DeleteTelefoneFuncionario(int id)
        {
            ServiceResponse<List<TelefoneFuncionario>> serviceResponse = new ServiceResponse<List<TelefoneFuncionario>>();
            try
            {
                var telefoneFuncionario = await _context.TelefoneFuncionario.FindAsync(id);
                if (telefoneFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "TelefoneFuncionario not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    _context.TelefoneFuncionario.Remove(telefoneFuncionario);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.TelefoneFuncionario.ToListAsync();
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
