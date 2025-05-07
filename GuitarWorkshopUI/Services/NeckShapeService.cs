using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class NeckShapeService : INeckShapeService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;

        public NeckShapeService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateNeckShape(NeckShapeDTO neckShapeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.NeckShapes.AddAsync(new NeckShape
            {
                ShapeName = neckShapeDTO.ShapeName,
                Price = neckShapeDTO.Price,
            });
            await context.SaveChangesAsync();
        }

        public async Task DeletNeckShape(NeckShapeDTO neckShapeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = neckShapeDTO.ShapeId;
            await context.NeckShapes.Where(x => x.ShapeId == id).ExecuteDeleteAsync();
        }

        public async Task<List<NeckShapeDTO>> GetAllNeckShapes()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<NeckShapeDTO> data = await context.NeckShapes.Select(x => new NeckShapeDTO
            {
                ShapeId = x.ShapeId,
                ShapeName = x.ShapeName,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task UpdateNeckShape(NeckShapeDTO neckShapeDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = neckShapeDTO.ShapeId;
            await context.NeckShapes.Where(x => x.ShapeId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.ShapeName, neckShapeDTO.ShapeName)
                .SetProperty(x => x.Price, neckShapeDTO.Price)
            );
        }
    }
}
