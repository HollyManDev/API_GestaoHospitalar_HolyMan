using GestaoHospitalar.DataContext;
using GestaoHospitalar.Models;
using GestaoHospitalar.ModelsView;
using GestaoHospitalar.ServerResponse;
using Microsoft.EntityFrameworkCore;

namespace GestaoHospitalar.Services.CargoServices
{
    public class CargoService : CargoInterface
    {
        private readonly ApplicationDbContext _context;

        public CargoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Cargo>>> GetCargos()
        {
            var serviceResponse = new ServiceResponse<List<Cargo>>();

            try
            {
                serviceResponse.Data = await _context.Cargos.ToListAsync();

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

        public async Task<ServiceResponse<Cargo>> FindCargo(int id)
        {
            var serviceResponse = new ServiceResponse<Cargo>();

            try
            {
                var leito = await _context.Cargos.FirstOrDefaultAsync(c => c.CargoID == id);

                if (leito == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Leito not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = leito;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Cargo>>> CreateCargo(CargoView newCargo)
        {
            var serviceResponse = new ServiceResponse<List<Cargo>>();

            try
            {
                var cargo = new Cargo
                {
                    Descricao = newCargo.Descricao,
                    Status = newCargo.Status
                };

                _context.Cargos.Add(cargo);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Cargos.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Cargo>>> UpdateCargo(CargoView updateLeito)
        {
            var serviceResponse = new ServiceResponse<List<Cargo>>();

            try
            {
                var leito = await _context.Cargos.FirstOrDefaultAsync(l => l.CargoID == updateLeito.CargoID);

                if (leito == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Leito not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    leito.Descricao = updateLeito.Descricao;
                    leito.Status = updateLeito.Status;

                    _context.Cargos.Update(leito);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Cargos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.menssage = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Cargo>>> DeleteCargo(int id)
        {
            var serviceResponse = new ServiceResponse<List<Cargo>>();

            try
            {
                var leito = await _context.Cargos.FirstOrDefaultAsync(l => l.CargoID == id);

                if (leito == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.menssage = "Leito not found!";
                    serviceResponse.Success = false;
                }
                else
                {
                    leito.Status = false;
                    _context.Cargos.Update(leito);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Cargos.ToListAsync();
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
