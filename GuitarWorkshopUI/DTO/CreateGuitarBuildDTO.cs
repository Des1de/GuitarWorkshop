using GuitarWorkshopUI.DTO.GuitarParts;
using System.ComponentModel.DataAnnotations;

namespace GuitarWorkshopUI.DTO
{
    public class CreateGuitarBuildDTO
    {
        public int BuildId { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }

        [Required]
        public int BodyShapeId { get; set; }

        [Required]
        public int BottomDeckMaterialId { get; set; }

        [Required]
        public int ColorId { get; set; }

        [Required]
        public int FingerboardMaterialId { get; set; }

        [Required]
        public int FinishId { get; set; }

        [Required]
        public int FretNubmberTypeId { get; set; }

        [Required]
        public int HeadstockStyleId { get; set; }

        [Required]
        public int NeckMaterialId { get; set; }

        [Required]
        public int NeckScaleId { get; set; }

        [Required]
        public int NeckShapeId { get; set; }

        [Required]
        public int StringId { get; set; }

        [Required]
        public int TopDeckMaterialId { get; set; }

        [Required]
        public int TuningMachineId { get; set; }
    }
}
