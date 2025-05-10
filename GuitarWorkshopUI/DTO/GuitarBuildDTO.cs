using GuitarWorkshopUI.DTO.GuitarParts;
using System.ComponentModel.DataAnnotations;

namespace GuitarWorkshopUI.DTO
{
    public class GuitarBuildDTO
    {
        public int BuildId { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual int UserId { get; set; }
        [Required]
        public virtual BodyShapeDTO BodyShape { get; set; }
        [Required]
        public virtual WoodsTypeDTO BottomDeckMaterial { get; set; }
        [Required]
        public virtual GuitarColorDTO Color { get; set; }
        [Required]
        public virtual WoodsTypeDTO FingerboardMaterial { get; set; }
        [Required]
        public virtual FinishDTO Finish { get; set; }
        [Required]
        public virtual FretNumberTypeDTO FretNubmberType { get; set; }
        [Required]
        public virtual HeadstockStyleDTO HeadstockStyle { get; set; }
        [Required]
        public virtual WoodsTypeDTO NeckMaterial { get; set; }
        [Required]
        public virtual NeckScaleDTO NeckScale { get; set; }
        [Required]
        public virtual NeckShapeDTO NeckShape { get; set; }
        [Required]
        public virtual StringTypeDTO String { get; set; }
        [Required]
        public virtual WoodsTypeDTO TopDeckMaterial { get; set; }
        [Required]
        public virtual TuningMachineDTO TuningMachine { get; set; }

    }
}
