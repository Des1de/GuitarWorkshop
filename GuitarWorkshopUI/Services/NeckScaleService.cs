using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class NeckScaleService : INeckScaleService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public NeckScaleService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateNeckScale(NeckScaleDTO neckScaleDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.NeckScales.AddAsync(new NeckScale
            {
                ScaleLength = neckScaleDTO.ScaleLength,
                Price = neckScaleDTO.Price,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeletNeckScale(NeckScaleDTO neckScaleDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = neckScaleDTO.ScaleId;
            await context.NeckScales.Where(x => x.ScaleId == id).ExecuteDeleteAsync();
        }

        public async Task<List<NeckScaleDTO>> GetAllNeckScales()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<NeckScaleDTO> data = await context.NeckScales.Select(x => new NeckScaleDTO
            {
                ScaleId = x.ScaleId,
                ScaleLength = x.ScaleLength,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task UpdateNeckScale(NeckScaleDTO neckScaleDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = neckScaleDTO.ScaleId;
            await context.NeckScales.Where(x => x.ScaleId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.ScaleLength, neckScaleDTO.ScaleLength)
                .SetProperty(x => x.Price, neckScaleDTO.Price)
            );
        }
    }
}
