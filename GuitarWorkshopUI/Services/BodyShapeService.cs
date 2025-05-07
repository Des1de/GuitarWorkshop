using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class BodyShapeService : IBodyShapeService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public BodyShapeService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateBodyShape(BodyShapeDTO bodyShapeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.BodyShapes.AddAsync(new BodyShape
            {
                ShapeName = bodyShapeDTO.ShapeName,
                Price = bodyShapeDTO.Price
            });
            await context.SaveChangesAsync();
        }

        public async Task DeleteBodyShape(BodyShapeDTO bodyShapeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = bodyShapeDTO.ShapeId;
            await context.BodyShapes.Where(x => x.ShapeId == id).ExecuteDeleteAsync();
        }

        public async Task<List<BodyShapeDTO>> GetAllBodyShape()
        {
            using var context = _dbContextFactory.CreateDbContext(); 
            List<BodyShapeDTO> data = await context.BodyShapes.Select(x => new BodyShapeDTO
            {
                ShapeId = x.ShapeId,
                ShapeName = x.ShapeName,
                Price = x.Price
            }).ToListAsync();
            return data; 
        }

        public async Task UpdateBodyShape(BodyShapeDTO bodyShapeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = bodyShapeDTO.ShapeId;
            await context.BodyShapes.Where(x => x.ShapeId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.ShapeName, bodyShapeDTO.ShapeName)
                .SetProperty(x => x.Price, bodyShapeDTO.Price)
            );        
        }
    }
}
