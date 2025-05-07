using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class GuitarBuildService : IGuitarBuildService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;
        public GuitarBuildService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateGuitarBuild(GuitarBuildDTO guitarBuildDTO)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.GuitarBuilds.AddAsync(new GuitarBuild
            {
                UserId = guitarBuildDTO.UserId,
                BodyShapeId = guitarBuildDTO.BodyShape.ShapeId,
                TopDeckMaterialId = guitarBuildDTO.TopDeckMaterial.TypeId,
                BottomDeckMaterialId = guitarBuildDTO.BottomDeckMaterial.TypeId,
                NeckMaterialId = guitarBuildDTO.NeckMaterial.TypeId,
                NeckShapeId = guitarBuildDTO.NeckShape.ShapeId,
                NeckScaleId = guitarBuildDTO.NeckScale.ScaleId,
                FretNubmberTypeId = guitarBuildDTO.FretNubmberType.TypeId,
                FingerboardMaterialId = guitarBuildDTO.FingerboardMaterial.TypeId,
                HeadstockStyleId = guitarBuildDTO.HeadstockStyle.StyleId,
                TuningMachineId = guitarBuildDTO.TuningMachine.MachineId,
                ColorId = guitarBuildDTO.Color.ColorId,
                FinishId = guitarBuildDTO.Finish.FinishId,
                StringId = guitarBuildDTO.String.StringId,
                TotalPrice = guitarBuildDTO.TotalPrice
            });
            await context.SaveChangesAsync();
        }

        public async Task DeleteGuitarBuild(GuitarBuildDTO guitarBuildDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = guitarBuildDTO.BuildId;
            await context.GuitarBuilds.Where(x => x.BuildId == id).ExecuteDeleteAsync();
        }

        public async Task<List<GuitarBuildDTO>> GetAllGuitarBuilds()
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<GuitarBuildDTO> data = await context.GuitarBuilds
                .Include(x => x.BodyShape)
                .Include(x => x.TopDeckMaterial)
                .Include(x => x.BottomDeckMaterial)
                .Include(x => x.NeckMaterial)
                .Include(x => x.NeckShape)
                .Include(x => x.NeckScale)
                .Include(x => x.FretNubmberType)
                .Include(x => x.FingerboardMaterial)
                .Include(x => x.HeadstockStyle)
                .Include(x => x.TuningMachine)
                .Include(x => x.Color)
                .Include(x => x.Finish)
                .Include(x => x.String)
                .Select(x => new GuitarBuildDTO
                {
                    BuildId = x.BuildId,
                    TotalPrice = x.TotalPrice,
                    UserId = x.UserId,
                    BodyShape = new BodyShapeDTO
                    {
                        ShapeId = x.BodyShape.ShapeId,
                        ShapeName = x.BodyShape.ShapeName,
                        Price = x.BodyShape.Price,
                    },
                    TopDeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.TopDeckMaterial.TypeId,
                        PartType = x.TopDeckMaterial.PartType,
                        WoodName = x.TopDeckMaterial.WoodName,
                        Price = x.TopDeckMaterial.Price
                    },
                    BottomDeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.BottomDeckMaterial.TypeId,
                        PartType = x.BottomDeckMaterial.PartType,
                        WoodName = x.BottomDeckMaterial.WoodName,
                        Price = x.BottomDeckMaterial.Price
                    },
                    NeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.NeckMaterial.TypeId,
                        PartType = x.NeckMaterial.PartType,
                        WoodName = x.NeckMaterial.WoodName,
                        Price = x.NeckMaterial.Price
                    },
                    NeckShape = new NeckShapeDTO
                    {
                        ShapeId = x.NeckShape.ShapeId,
                        ShapeName = x.NeckShape.ShapeName,
                        Price = x.NeckShape.Price,
                    },
                    NeckScale = new NeckScaleDTO
                    {
                        ScaleId = x.NeckScale.ScaleId,
                        ScaleLength = x.NeckScale.ScaleLength, 
                        Price = x.NeckScale.Price,
                    },
                    FretNubmberType = new FretNumberTypeDTO
                    {
                        TypeId = x.FretNubmberTypeId,
                        FretNumber = x.FretNubmberType.FretNumber,
                        Price = x.FretNubmberType.Price,
                    },
                    FingerboardMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.FingerboardMaterial.TypeId,
                        PartType = x.FingerboardMaterial.PartType,
                        WoodName = x.FingerboardMaterial.WoodName,
                        Price = x.FingerboardMaterial.Price
                    },
                    HeadstockStyle = new HeadstockStyleDTO
                    {
                        StyleId = x.HeadstockStyle.StyleId,
                        StyleName = x.HeadstockStyle.StyleName,
                        Price = x.HeadstockStyle.Price,
                    },
                    TuningMachine = new TuningMachineDTO
                    {
                        MachineId = x.TuningMachine.MachineId,
                        MachineName = x.TuningMachine.MachineName,
                        Price= x.TuningMachine.Price,
                    },
                    Color = new GuitarColorDTO
                    {
                        ColorId = x.Color.ColorId,
                        Color = x.Color.Color,
                    },
                    Finish = new FinishDTO
                    {
                        FinishId = x.Finish.FinishId,
                        FinishName = x.Finish.FinishName,
                        Price = x.Finish.Price,
                    },
                    String = new StringTypeDTO
                    {
                        StringId = x.String.StringId,
                        StringName = x.String.StringName,
                        Price = x.String.Price,
                    }
                }).ToListAsync();
            return data;
        }

        public async Task<GuitarBuildDTO> GetGuitarBuild(int buildId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            GuitarBuildDTO data = await context.GuitarBuilds
                .Include(x => x.BodyShape)
                .Include(x => x.TopDeckMaterial)
                .Include(x => x.BottomDeckMaterial)
                .Include(x => x.NeckMaterial)
                .Include(x => x.NeckShape)
                .Include(x => x.NeckScale)
                .Include(x => x.FretNubmberType)
                .Include(x => x.FingerboardMaterial)
                .Include(x => x.HeadstockStyle)
                .Include(x => x.TuningMachine)
                .Include(x => x.Color)
                .Include(x => x.Finish)
                .Include(x => x.String)
                .Where(x => x.BuildId == buildId)
                .Select(x => new GuitarBuildDTO
                {
                    BuildId = x.BuildId,
                    TotalPrice = x.TotalPrice,
                    UserId = x.UserId,
                    BodyShape = new BodyShapeDTO
                    {
                        ShapeId = x.BodyShape.ShapeId,
                        ShapeName = x.BodyShape.ShapeName,
                        Price = x.BodyShape.Price,
                    },
                    TopDeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.TopDeckMaterial.TypeId,
                        PartType = x.TopDeckMaterial.PartType,
                        WoodName = x.TopDeckMaterial.WoodName,
                        Price = x.TopDeckMaterial.Price
                    },
                    BottomDeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.BottomDeckMaterial.TypeId,
                        PartType = x.BottomDeckMaterial.PartType,
                        WoodName = x.BottomDeckMaterial.WoodName,
                        Price = x.BottomDeckMaterial.Price
                    },
                    NeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.NeckMaterial.TypeId,
                        PartType = x.NeckMaterial.PartType,
                        WoodName = x.NeckMaterial.WoodName,
                        Price = x.NeckMaterial.Price
                    },
                    NeckShape = new NeckShapeDTO
                    {
                        ShapeId = x.NeckShape.ShapeId,
                        ShapeName = x.NeckShape.ShapeName,
                        Price = x.NeckShape.Price,
                    },
                    NeckScale = new NeckScaleDTO
                    {
                        ScaleId = x.NeckScale.ScaleId,
                        ScaleLength = x.NeckScale.ScaleLength,
                        Price = x.NeckScale.Price,
                    },
                    FretNubmberType = new FretNumberTypeDTO
                    {
                        TypeId = x.FretNubmberTypeId,
                        FretNumber = x.FretNubmberType.FretNumber,
                        Price = x.FretNubmberType.Price,
                    },
                    FingerboardMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.FingerboardMaterial.TypeId,
                        PartType = x.FingerboardMaterial.PartType,
                        WoodName = x.FingerboardMaterial.WoodName,
                        Price = x.FingerboardMaterial.Price
                    },
                    HeadstockStyle = new HeadstockStyleDTO
                    {
                        StyleId = x.HeadstockStyle.StyleId,
                        StyleName = x.HeadstockStyle.StyleName,
                        Price = x.HeadstockStyle.Price,
                    },
                    TuningMachine = new TuningMachineDTO
                    {
                        MachineId = x.TuningMachine.MachineId,
                        MachineName = x.TuningMachine.MachineName,
                        Price = x.TuningMachine.Price,
                    },
                    Color = new GuitarColorDTO
                    {
                        ColorId = x.Color.ColorId,
                        Color = x.Color.Color,
                    },
                    Finish = new FinishDTO
                    {
                        FinishId = x.Finish.FinishId,
                        FinishName = x.Finish.FinishName,
                        Price = x.Finish.Price,
                    },
                    String = new StringTypeDTO
                    {
                        StringId = x.String.StringId,
                        StringName = x.String.StringName,
                        Price = x.String.Price,
                    }
                }).SingleAsync();
            return data;
        }

        public async Task<List<GuitarBuildDTO>> GetGuitarBuildsByUserId(int userId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            List<GuitarBuildDTO> data = await context.GuitarBuilds
                .Include(x => x.BodyShape)
                .Include(x => x.TopDeckMaterial)
                .Include(x => x.BottomDeckMaterial)
                .Include(x => x.NeckMaterial)
                .Include(x => x.NeckShape)
                .Include(x => x.NeckScale)
                .Include(x => x.FretNubmberType)
                .Include(x => x.FingerboardMaterial)
                .Include(x => x.HeadstockStyle)
                .Include(x => x.TuningMachine)
                .Include(x => x.Color)
                .Include(x => x.Finish)
                .Include(x => x.String)
                .Where(x => x.UserId == userId)
                .Select(x => new GuitarBuildDTO
                {
                    BuildId = x.BuildId,
                    TotalPrice = x.TotalPrice,
                    UserId = x.UserId,
                    BodyShape = new BodyShapeDTO
                    {
                        ShapeId = x.BodyShape.ShapeId,
                        ShapeName = x.BodyShape.ShapeName,
                        Price = x.BodyShape.Price,
                    },
                    TopDeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.TopDeckMaterial.TypeId,
                        PartType = x.TopDeckMaterial.PartType,
                        WoodName = x.TopDeckMaterial.WoodName,
                        Price = x.TopDeckMaterial.Price
                    },
                    BottomDeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.BottomDeckMaterial.TypeId,
                        PartType = x.BottomDeckMaterial.PartType,
                        WoodName = x.BottomDeckMaterial.WoodName,
                        Price = x.BottomDeckMaterial.Price
                    },
                    NeckMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.NeckMaterial.TypeId,
                        PartType = x.NeckMaterial.PartType,
                        WoodName = x.NeckMaterial.WoodName,
                        Price = x.NeckMaterial.Price
                    },
                    NeckShape = new NeckShapeDTO
                    {
                        ShapeId = x.NeckShape.ShapeId,
                        ShapeName = x.NeckShape.ShapeName,
                        Price = x.NeckShape.Price,
                    },
                    NeckScale = new NeckScaleDTO
                    {
                        ScaleId = x.NeckScale.ScaleId,
                        ScaleLength = x.NeckScale.ScaleLength,
                        Price = x.NeckScale.Price,
                    },
                    FretNubmberType = new FretNumberTypeDTO
                    {
                        TypeId = x.FretNubmberTypeId,
                        FretNumber = x.FretNubmberType.FretNumber,
                        Price = x.FretNubmberType.Price,
                    },
                    FingerboardMaterial = new WoodsTypeDTO
                    {
                        TypeId = x.FingerboardMaterial.TypeId,
                        PartType = x.FingerboardMaterial.PartType,
                        WoodName = x.FingerboardMaterial.WoodName,
                        Price = x.FingerboardMaterial.Price
                    },
                    HeadstockStyle = new HeadstockStyleDTO
                    {
                        StyleId = x.HeadstockStyle.StyleId,
                        StyleName = x.HeadstockStyle.StyleName,
                        Price = x.HeadstockStyle.Price,
                    },
                    TuningMachine = new TuningMachineDTO
                    {
                        MachineId = x.TuningMachine.MachineId,
                        MachineName = x.TuningMachine.MachineName,
                        Price = x.TuningMachine.Price,
                    },
                    Color = new GuitarColorDTO
                    {
                        ColorId = x.Color.ColorId,
                        Color = x.Color.Color,
                    },
                    Finish = new FinishDTO
                    {
                        FinishId = x.Finish.FinishId,
                        FinishName = x.Finish.FinishName,
                        Price = x.Finish.Price,
                    },
                    String = new StringTypeDTO
                    {
                        StringId = x.String.StringId,
                        StringName = x.String.StringName,
                        Price = x.String.Price,
                    }
                }).ToListAsync();
            return data;
        }

        public async Task UpdateGuitarBuild(GuitarBuildDTO guitarBuildDTO)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int id = guitarBuildDTO.BuildId;
            await context.GuitarBuilds.Where(x => x.BuildId == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.BodyShapeId, guitarBuildDTO.BodyShape.ShapeId)
                .SetProperty(x => x.TopDeckMaterialId, guitarBuildDTO.TopDeckMaterial.TypeId)
                .SetProperty(x => x.BottomDeckMaterialId, guitarBuildDTO.BottomDeckMaterial.TypeId)
                .SetProperty(x => x.NeckMaterialId, guitarBuildDTO.NeckMaterial.TypeId)
                .SetProperty(x => x.NeckShapeId, guitarBuildDTO.NeckShape.ShapeId)
                .SetProperty(x => x.NeckScaleId, guitarBuildDTO.NeckScale.ScaleId)
                .SetProperty(x => x.FretNubmberTypeId, guitarBuildDTO.FretNubmberType.TypeId)
                .SetProperty(x => x.FingerboardMaterialId, guitarBuildDTO.FingerboardMaterial.TypeId)
                .SetProperty(x => x.HeadstockStyleId, guitarBuildDTO.HeadstockStyle.StyleId)
                .SetProperty(x => x.TuningMachineId, guitarBuildDTO.TuningMachine.MachineId)
                .SetProperty(x => x.ColorId, guitarBuildDTO.Color.ColorId)
                .SetProperty(x => x.FinishId, guitarBuildDTO.Finish.FinishId)
                .SetProperty(x => x.StringId, guitarBuildDTO.String.StringId)
            );
        }
    }
}
