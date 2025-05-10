using GuitarWorkshopUI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuitarWorkshopUI.Interfaces;
using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Pages.Constructor
{
    public class GuitarBuilderModel : PageModel
    {
        private readonly IGuitarBuildService _guitarBuildService;
        private readonly IBodyShapeService _bodyShapeService;
        private readonly IFinishesService _finishesService;
        private readonly IFretNumberTypeService _fretNumberTypeService;
        private readonly IGuitarColorService _guitarColorService;
        private readonly IHeadstockStyleService _headstockStyleService;
        private readonly INeckScaleService _neckScaleService;
        private readonly INeckShapeService _neckShapeService;
        private readonly IStringTypeService _stringTypeService;
        private readonly ITuningMachineService _tuningMachineService;
        private readonly IWoodsTypeService _woodsTypeService;
        [BindProperty]
        public GuitarBuildDTO GuitarBuild { get; set; }

        public List<BodyShapeDTO> BodyShapes { get; set; }
        public List<WoodsTypeDTO> WoodsTypes { get; set; }
        public List<GuitarColorDTO> GuitarColors { get; set; }
        public List<FinishDTO> Finishes { get; set; }
        public List<FretNumberTypeDTO> FretNumberTypes { get; set; }
        public List<HeadstockStyleDTO> HeadstockStyles { get; set; }
        public List<NeckScaleDTO> NeckScales { get; set; }
        public List<NeckShapeDTO> NeckShapes { get; set; }
        public List<StringTypeDTO> StringTypes { get; set; }
        public List<TuningMachineDTO> TuningMachines { get; set; }

        public SelectList BodyShapeOptions { get; set; }
        public SelectList BottomDeckMaterialOptions { get; set; }
        public SelectList ColorOptions { get; set; }
        public SelectList FingerboardMaterialOptions { get; set; }
        public SelectList FinishOptions { get; set; }
        public SelectList FretNubmberTypeOptions { get; set; }
        public SelectList HeadstockStyleOptions { get; set; }
        public SelectList NeckMaterialOptions { get; set; }
        public SelectList NeckScaleOptions { get; set; }
        public SelectList NeckShapeOptions { get; set; }
        public SelectList StringOptions { get; set; }
        public SelectList TopDeckMaterialOptions { get; set; }
        public SelectList TuningMachineOptions { get; set; }

        public GuitarBuilderModel(
            IGuitarBuildService guitarBuildService,
            IBodyShapeService bodyShapeService,
            IFinishesService finishesService,
            IFretNumberTypeService fretNumberTypeService,
            IGuitarColorService guitarColorService,
            IHeadstockStyleService headstockStyleService,
            INeckScaleService neckScaleService,
            INeckShapeService neckShapeService,
            IStringTypeService stringTypeService,
            ITuningMachineService tuningMachineService,
            IWoodsTypeService woodsTypeService
            )
        {
            _guitarBuildService = guitarBuildService;
            _bodyShapeService = bodyShapeService;
            _finishesService = finishesService;
            _fretNumberTypeService = fretNumberTypeService;
            _guitarColorService = guitarColorService;
            _headstockStyleService = headstockStyleService;
            _neckScaleService = neckScaleService;
            _neckShapeService = neckShapeService;
            _stringTypeService = stringTypeService;
            _tuningMachineService = tuningMachineService;
            _woodsTypeService = woodsTypeService;
        }

        public async Task OnGetAsync()
        {
            BodyShapes = await _bodyShapeService.GetAllBodyShape(); 
            WoodsTypes = await _woodsTypeService.GetAllWoodsTypes();
            GuitarColors = await _guitarColorService.GetAllGuitarColors();
            Finishes = await _finishesService.GetAllFinishes();
            FretNumberTypes = await _fretNumberTypeService.GetAllFretNumberTypes();
            HeadstockStyles = await _headstockStyleService.GetAllHeadstockStyles();
            NeckScales = await _neckScaleService.GetAllNeckScales();
            NeckShapes = await _neckShapeService.GetAllNeckShapes();
            StringTypes = await _stringTypeService.GetAllStringTypes();
            TuningMachines = await _tuningMachineService.GetAllTuningMachines();

            BodyShapeOptions = new(BodyShapes, "ShapeId", "ShapeName");
            BottomDeckMaterialOptions = new(WoodsTypes.Where(x => x.PartType == "BottomDeck").ToList(), "TypeId", "WoodName");
            ColorOptions = new(GuitarColors, "ColorId", "Color");
            FingerboardMaterialOptions = new(WoodsTypes.Where(x => x.PartType == "Fingerboard").ToList(), "TypeId", "WoodName");
            FinishOptions = new(await _finishesService.GetAllFinishes(), "FinishId", "FinishName");
            FretNubmberTypeOptions = new(FretNumberTypes, "TypeId", "FretNumber");
            HeadstockStyleOptions = new(HeadstockStyles, "StyleId", "StyleName");
            NeckMaterialOptions = new(WoodsTypes.Where(x => x.PartType == "Neck").ToList(), "TypeId", "WoodName");
            NeckScaleOptions = new(NeckScales, "ScaleId", "ScaleLength");
            NeckShapeOptions = new(NeckShapes, "ShapeId", "ShapeName");
            StringOptions = new(StringTypes, "StringId", "StringName");
            TopDeckMaterialOptions = new(WoodsTypes.Where(x => x.PartType == "TopDeck").ToList(), "TypeId", "WoodName");
            TuningMachineOptions = new(TuningMachines, "MachineId", "MachineName");
        }
        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                GuitarBuild.TotalPrice = CalculatePrice(); 
                await _guitarBuildService.CreateGuitarBuild(GuitarBuild);
            }
                
            else
            {
                BodyShapes = await _bodyShapeService.GetAllBodyShape();
                WoodsTypes = await _woodsTypeService.GetAllWoodsTypes();
                GuitarColors = await _guitarColorService.GetAllGuitarColors();
                Finishes = await _finishesService.GetAllFinishes();
                FretNumberTypes = await _fretNumberTypeService.GetAllFretNumberTypes();
                HeadstockStyles = await _headstockStyleService.GetAllHeadstockStyles();
                NeckScales = await _neckScaleService.GetAllNeckScales();
                NeckShapes = await _neckShapeService.GetAllNeckShapes();
                StringTypes = await _stringTypeService.GetAllStringTypes();
                TuningMachines = await _tuningMachineService.GetAllTuningMachines();

                BodyShapeOptions = new(BodyShapes, "ShapeId", "ShapeName");
                BottomDeckMaterialOptions = new(WoodsTypes.Where(x => x.PartType == "BottomDeck").ToList(), "TypeId", "WoodName");
                ColorOptions = new(GuitarColors, "ColorId", "Color");
                FingerboardMaterialOptions = new(WoodsTypes.Where(x => x.PartType == "Fingerboard").ToList(), "TypeId", "WoodName");
                FinishOptions = new(await _finishesService.GetAllFinishes(), "FinishId", "FinishName");
                FretNubmberTypeOptions = new(FretNumberTypes, "TypeId", "FretNumber");
                HeadstockStyleOptions = new(HeadstockStyles, "StyleId", "StyleName");
                NeckMaterialOptions = new(WoodsTypes.Where(x => x.PartType == "Neck").ToList(), "TypeId", "WoodName");
                NeckScaleOptions = new(NeckScales, "ScaleId", "ScaleLength");
                NeckShapeOptions = new(NeckShapes, "ShapeId", "ShapeName");
                StringOptions = new(StringTypes, "StringId", "StringName");
                TopDeckMaterialOptions = new(WoodsTypes.Where(x => x.PartType == "TopDeck").ToList(), "TypeId", "WoodName");
                TuningMachineOptions = new(TuningMachines, "MachineId", "MachineName");
            }
        }

        private decimal CalculatePrice()
        {
            return 0; 
        }
    }
}
