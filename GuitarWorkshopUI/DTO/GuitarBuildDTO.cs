﻿using GuitarWorkshopUI.DTO.GuitarParts;
using System.ComponentModel.DataAnnotations;

namespace GuitarWorkshopUI.DTO
{
    public class GuitarBuildDTO
    {
        public int BuildId { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }

        [Required]
        public int BodyShapeId { get; set; }
        public BodyShapeDTO BodyShape { get; set; }

        [Required]
        public int BottomDeckMaterialId { get; set; }
        public WoodsTypeDTO BottomDeckMaterial { get; set; }

        [Required]
        public int ColorId { get; set; }
        public GuitarColorDTO Color { get; set; }

        [Required]
        public int FingerboardMaterialId { get; set; }
        public WoodsTypeDTO FingerboardMaterial { get; set; }

        [Required]
        public int FinishId { get; set; }
        public FinishDTO Finish { get; set; }

        [Required]
        public int FretNubmberTypeId { get; set; }
        public FretNumberTypeDTO FretNubmberType { get; set; }

        [Required]
        public int HeadstockStyleId { get; set; }
        public HeadstockStyleDTO HeadstockStyle { get; set; }

        [Required]
        public int NeckMaterialId { get; set; }
        public WoodsTypeDTO NeckMaterial { get; set; }

        [Required]
        public int NeckScaleId { get; set; }
        public NeckScaleDTO NeckScale { get; set; }

        [Required]
        public int NeckShapeId { get; set; }
        public NeckShapeDTO NeckShape { get; set; }

        [Required]
        public int StringId { get; set; }
        public StringTypeDTO String { get; set; }

        [Required]
        public int TopDeckMaterialId { get; set; }
        public WoodsTypeDTO TopDeckMaterial { get; set; }

        [Required]
        public int TuningMachineId { get; set; }
        public TuningMachineDTO TuningMachine { get; set; }
    }

}
