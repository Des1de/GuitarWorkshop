using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IBodyShapeService
    {
        Task<List<BodyShapeDTO>> GetAllBodyShape();
        Task CreateBodyShape(BodyShapeDTO bodyShapeDTO);
        Task DeleteBodyShape(BodyShapeDTO bodyShapeDTO);
        Task UpdateBodyShape(BodyShapeDTO bodyShapeDTO);
    }
}
