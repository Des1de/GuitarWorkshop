using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class WoodsTypeService : IWoodsTypeService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public WoodsTypeService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateWoodsType(WoodsTypeDTO woodsTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.WoodsTypes.AddAsync(new WoodsType
            {
                WoodName = woodsTypeDTO.WoodName,
                PartType = woodsTypeDTO.PartType,
                Price = woodsTypeDTO.Price,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeletWoodsType(WoodsTypeDTO woodsTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = woodsTypeDTO.TypeId;
            await context.WoodsTypes.Where(x => x.TypeId == id).ExecuteDeleteAsync();
        }

        public async Task<List<WoodsTypeDTO>> GetAllWoodsTypes()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<WoodsTypeDTO> data = await context.WoodsTypes.Select(x => new WoodsTypeDTO
            {
                TypeId = x.TypeId,
                WoodName = x.WoodName,
                PartType = x.PartType,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task UpdateWoodsType(WoodsTypeDTO woodsTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = woodsTypeDTO.TypeId;
            await context.WoodsTypes.Where(x => x.TypeId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.WoodName, woodsTypeDTO.WoodName)
                .SetProperty(x => x.PartType, woodsTypeDTO.PartType)
                .SetProperty(x => x.Price, woodsTypeDTO.Price)
            );
        }
    }
}
