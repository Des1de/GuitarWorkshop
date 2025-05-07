using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class FretNumberTypeService : IFretNumberTypeService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public FretNumberTypeService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateFretNumberType(FretNumberTypeDTO fretNumberTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.FretNumberTypes.AddAsync(new FretNumberType
            {
                FretNumber = fretNumberTypeDTO.FretNumber,
                Price = fretNumberTypeDTO.Price,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeleteFretNumberType(FretNumberTypeDTO fretNumberTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = fretNumberTypeDTO.TypeId;
            await context.FretNumberTypes.Where(x => x.TypeId == id).ExecuteDeleteAsync();
        }

        public async Task<List<FretNumberTypeDTO>> GetAllFretNumberTypes()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<FretNumberTypeDTO> data = await context.FretNumberTypes.Select(x => new FretNumberTypeDTO
            {
                TypeId = x.TypeId,
                FretNumber = x.FretNumber,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task UpdateFretNumberType(FretNumberTypeDTO fretNumberTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = fretNumberTypeDTO.TypeId;
            await context.FretNumberTypes.Where(x => x.TypeId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.FretNumber, fretNumberTypeDTO.FretNumber)
                .SetProperty(x => x.Price, fretNumberTypeDTO.Price)
            );
        }
    }
}
