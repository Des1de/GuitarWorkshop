using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class StringTypeService : IStringTypeService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public StringTypeService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateStringType(StringTypeDTO stringTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.StringTypes.AddAsync(new StringType
            {
                StringName = stringTypeDTO.StringName,
                Price = stringTypeDTO.Price,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeletStringType(StringTypeDTO stringTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = stringTypeDTO.StringId;
            await context.StringTypes.Where(x => x.StringId == id).ExecuteDeleteAsync();
        }

        public async Task<List<StringTypeDTO>> GetAllStringTypes()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<StringTypeDTO> data = await context.StringTypes.Select(x => new StringTypeDTO
            {
                StringId = x.StringId,
                StringName = x.StringName,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task UpdateStringType(StringTypeDTO stringTypeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = stringTypeDTO.StringId;
            await context.StringTypes.Where(x => x.StringId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.StringName, stringTypeDTO.StringName)
                .SetProperty(x => x.Price, stringTypeDTO.Price)
            );
        }
    }
}
