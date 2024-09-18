using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.FuncionarioServices
{
    public class FuncionarioService : FuncionarioInterface
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Funcionario>>> GetFuncionarios()
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                serviceResponse.Data = await _context.Funcionarios.ToListAsync();

                if (serviceResponse.Data.Count == 0)
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

        public async Task<ServiceResponse<Funcionario>> FindFuncionario(int id)
        {
            ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

            try
            {
                Funcionario gotFuncionario = await _context.Funcionarios.FindAsync(id);

                if (gotFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Funcionario not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = gotFuncionario;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> CreateFuncionario(FuncionarioView newFuncionario)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                var funcionarioModel = new Funcionario
                {
                    Nome = newFuncionario.Nome,
                    Cargo = newFuncionario.Cargo,
                    Telefone = newFuncionario.Telefone,
                    Email = newFuncionario.Email,
                    Endereco = newFuncionario.Endereco,
                    DataContratacao = newFuncionario.DataContratacao,
                    Departamento = newFuncionario.Departamento,
                    Status = newFuncionario.Status,
                    departamentoFuncionario = await _context.DepartamentosFuncionarios.FindAsync(newFuncionario.DepartamentoFuncionario)
                };

                _context.Funcionarios.Add(funcionarioModel);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Funcionarios.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> UpdateFuncionario(FuncionarioView updateFuncionario)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                Funcionario gotFuncionario = await _context.Funcionarios.FindAsync(updateFuncionario.FuncionarioID);

                if (gotFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Funcionario not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    gotFuncionario.Nome = updateFuncionario.Nome;
                    gotFuncionario.Cargo = updateFuncionario.Cargo;
                    gotFuncionario.Telefone = updateFuncionario.Telefone;
                    gotFuncionario.Email = updateFuncionario.Email;
                    gotFuncionario.Endereco = updateFuncionario.Endereco;
                    gotFuncionario.DataContratacao = updateFuncionario.DataContratacao;
                    gotFuncionario.Departamento = updateFuncionario.Departamento;
                    gotFuncionario.Status = updateFuncionario.Status;
                    gotFuncionario.departamentoFuncionario = await _context.DepartamentosFuncionarios.FindAsync(updateFuncionario.DepartamentoFuncionario);

                    _context.Funcionarios.Update(gotFuncionario);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Funcionarios.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> InactivateFuncionario(int id)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                Funcionario gotFuncionario = await _context.Funcionarios.FindAsync(id);

                if (gotFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Funcionario not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    gotFuncionario.Status = false;
                    _context.Funcionarios.Update(gotFuncionario);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Funcionarios.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> ActivateFuncionario(int id)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                Funcionario gotFuncionario = await _context.Funcionarios.FindAsync(id);

                if (gotFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Funcionario not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    gotFuncionario.Status = true;
                    _context.Funcionarios.Update(gotFuncionario);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Funcionarios.ToListAsync();
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
