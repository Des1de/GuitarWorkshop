using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class FinishesService : IFinishesService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public FinishesService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateFinish(FinishDTO finishDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.Finishes.AddAsync(new Finish
            {
                FinishName = finishDTO.FinishName,
                Price = finishDTO.Price,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeleteFinish(FinishDTO finishDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = finishDTO.FinishId;
            await context.Finishes.Where(x => x.FinishId == id).ExecuteDeleteAsync();
        }

        public async Task<List<FinishDTO>> GetAllFinishes()
        {
            using var context = _dbContextFactory.CreateDbContext(); 
            List<FinishDTO> data = await context.Finishes.Select(x => new FinishDTO
            {
                FinishId = x.FinishId,
                FinishName = x.FinishName,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task UpdateFinish(FinishDTO finishDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = finishDTO.FinishId;
            await context.Finishes.Where(x => x.FinishId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.FinishName, finishDTO.FinishName)
                .SetProperty(x => x.Price, finishDTO.Price)
            );
        }
    }
}
