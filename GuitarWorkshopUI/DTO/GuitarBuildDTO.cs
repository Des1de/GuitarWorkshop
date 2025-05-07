using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.DTO
{
    public class GuitarBuildDTO
    {
        public int BuildId { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual int UserId { get; set; }

        public virtual BodyShapeDTO BodyShape { get; set; }

        public virtual WoodsTypeDTO BottomDeckMaterial { get; set; }

        public virtual GuitarColorDTO Color { get; set; }

        public virtual WoodsTypeDTO FingerboardMaterial { get; set; }

        public virtual FinishDTO Finish { get; set; }

        public virtual FretNumberTypeDTO FretNubmberType { get; set; }

        public virtual HeadstockStyleDTO HeadstockStyle { get; set; }

        public virtual WoodsTypeDTO NeckMaterial { get; set; }

        public virtual NeckScaleDTO NeckScale { get; set; }

        public virtual NeckShapeDTO NeckShape { get; set; }

        public virtual StringTypeDTO String { get; set; }

        public virtual WoodsTypeDTO TopDeckMaterial { get; set; }

        public virtual TuningMachineDTO TuningMachine { get; set; }

    }
}
