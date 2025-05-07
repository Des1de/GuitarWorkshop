using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class HeadstockStyleService : IHeadstockStyleService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public HeadstockStyleService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateHeadstockStyle(HeadstockStyleDTO headstockStyleDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.HeadstockStyles.AddAsync(new HeadstockStyle
            {
                StyleName = headstockStyleDTO.StyleName,
                Price = headstockStyleDTO.Price,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeleteHeadstockStyle(HeadstockStyleDTO headstockStyleDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = headstockStyleDTO.StyleId;
            await context.HeadstockStyles.Where(x => x.StyleId == id).ExecuteDeleteAsync();
        }

        public async Task<List<HeadstockStyleDTO>> GetAllHeadstockStyles()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<HeadstockStyleDTO> data = await context.HeadstockStyles.Select(x => new HeadstockStyleDTO
            {
                StyleId = x.StyleId,
                StyleName = x.StyleName,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task UpdateHeadstockStyle(HeadstockStyleDTO headstockStyleDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = headstockStyleDTO.StyleId;
            await context.HeadstockStyles.Where(x => x.StyleId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.StyleName, headstockStyleDTO.StyleName)
                .SetProperty(x => x.Price, headstockStyleDTO.Price)
            );
        }
    }
}
