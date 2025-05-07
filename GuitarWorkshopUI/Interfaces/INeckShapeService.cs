using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface INeckShapeService
    {
        Task<List<NeckShapeDTO>> GetAllNeckShapes();
        Task CreateNeckShape(NeckShapeDTO neckShapeDTO);
        Task DeletNeckShape(NeckShapeDTO neckShapeDTO);
        Task UpdateNeckShape(NeckShapeDTO neckShapeDTO);
    }
}
