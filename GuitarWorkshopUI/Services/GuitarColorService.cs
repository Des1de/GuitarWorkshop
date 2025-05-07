using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class GuitarColorService : IGuitarColorService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public GuitarColorService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateGuitarColor(GuitarColorDTO guitarColorDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.GuitarColors.AddAsync(new GuitarColor
            {
                Color = guitarColorDTO.Color,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeleteGuitarColor(GuitarColorDTO guitarColorDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = guitarColorDTO.ColorId;
            await context.GuitarColors.Where(x => x.ColorId == id).ExecuteDeleteAsync();
        }

        public async Task<List<GuitarColorDTO>> GetAllGuitarColors()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<GuitarColorDTO> data = await context.GuitarColors.Select(x => new GuitarColorDTO
            {
                Color = x.Color,
                ColorId = x.ColorId,
            }).ToListAsync();
            return data;
        }

        public async Task UpdateGuitarColor(GuitarColorDTO guitarColorDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = guitarColorDTO.ColorId;
            await context.GuitarColors.Where(x => x.ColorId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.Color, guitarColorDTO.Color)
            );
        }
    }
}
