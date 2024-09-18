using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHospitalar.Services.DepartamentoServices
{
    public class DepartamentoService : DepartamentoInterface
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<DepartamentosFuncionarios>>> GetDepartamentos()
        {
            ServiceResponse<List<DepartamentosFuncionarios>> serviceResponse = new ServiceResponse<List<DepartamentosFuncionarios>>();

            try
            {
                serviceResponse.Data = await _context.DepartamentosFuncionarios.ToListAsync();

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

        public async Task<ServiceResponse<DepartamentosFuncionarios>> FindDepartamento(int id)
        {
            ServiceResponse<DepartamentosFuncionarios> serviceResponse = new ServiceResponse<DepartamentosFuncionarios>();

            try
            {
                DepartamentosFuncionarios gotDepartamento = await _context.DepartamentosFuncionarios.FindAsync(id);

                if (gotDepartamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Departamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = gotDepartamento;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DepartamentosFuncionarios>>> CreateDepartamento(DepartamentoView newDepartamento)
        {
            ServiceResponse<List<DepartamentosFuncionarios>> serviceResponse = new ServiceResponse<List<DepartamentosFuncionarios>>();

            try
            {
                var departamentoModel = new DepartamentosFuncionarios
                {
                    Nome = newDepartamento.Nome,
                    Descricao = newDepartamento.Descricao,
                    Status = newDepartamento.Status
                };

                _context.DepartamentosFuncionarios.Add(departamentoModel);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.DepartamentosFuncionarios.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DepartamentosFuncionarios>>> UpdateDepartamento(DepartamentoView updateDepartamento)
        {
            ServiceResponse<List<DepartamentosFuncionarios>> serviceResponse = new ServiceResponse<List<DepartamentosFuncionarios>>();

            try
            {
                DepartamentosFuncionarios gotDepartamento = await _context.DepartamentosFuncionarios.FindAsync(updateDepartamento.DepartamentoID);

                if (gotDepartamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Departamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    gotDepartamento.Nome = updateDepartamento.Nome;
                    gotDepartamento.Descricao = updateDepartamento.Descricao;
                    gotDepartamento.Status = updateDepartamento.Status;

                    _context.DepartamentosFuncionarios.Update(gotDepartamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.DepartamentosFuncionarios.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DepartamentosFuncionarios>>> InactivateDepartamento(int id)
        {
            ServiceResponse<List<DepartamentosFuncionarios>> serviceResponse = new ServiceResponse<List<DepartamentosFuncionarios>>();

            try
            {
                DepartamentosFuncionarios gotDepartamento = await _context.DepartamentosFuncionarios.FindAsync(id);

                if (gotDepartamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Departamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    gotDepartamento.Status = false;
                    _context.DepartamentosFuncionarios.Update(gotDepartamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.DepartamentosFuncionarios.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DepartamentosFuncionarios>>> ActivateDepartamento(int id)
        {
            ServiceResponse<List<DepartamentosFuncionarios>> serviceResponse = new ServiceResponse<List<DepartamentosFuncionarios>>();

            try
            {
                DepartamentosFuncionarios gotDepartamento = await _context.DepartamentosFuncionarios.FindAsync(id);

                if (gotDepartamento == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Departamento not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    gotDepartamento.Status = true;
                    _context.DepartamentosFuncionarios.Update(gotDepartamento);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.DepartamentosFuncionarios.ToListAsync();
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
