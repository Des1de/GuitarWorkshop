using GuitarWorkshopUI.DTO.BodyShape;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IBodyShapeService
    {
        Task<BodyShapeDTO> GetAllBodyShape(); 
    }
}
