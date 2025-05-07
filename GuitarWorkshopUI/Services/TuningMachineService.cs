using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class TuningMachineService : ITuningMachineService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public TuningMachineService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateTuningMachine(TuningMachineDTO tuningMachineDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.TuningMachines.AddAsync(new TuningMachine
            {
                MachineName = tuningMachineDTO.MachineName,
                Price = tuningMachineDTO.Price,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeletTuningMachine(TuningMachineDTO tuningMachineDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = tuningMachineDTO.MachineId;
            await context.TuningMachines.Where(x => x.MachineId == id).ExecuteDeleteAsync();
        }

        public async Task<List<TuningMachineDTO>> GetAllTuningMachines()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<TuningMachineDTO> data = await context.TuningMachines.Select(x => new TuningMachineDTO
            {
                MachineId = x.MachineId,
                MachineName = x.MachineName,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task UpdateTuningMachine(TuningMachineDTO tuningMachineDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = tuningMachineDTO.MachineId;
            await context.TuningMachines.Where(x => x.MachineId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.MachineName, tuningMachineDTO.MachineName)
                .SetProperty(x => x.Price, tuningMachineDTO.Price)
            );
        }
    }
}
