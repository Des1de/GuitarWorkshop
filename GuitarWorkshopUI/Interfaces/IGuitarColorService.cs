using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IGuitarColorService
    {
        Task<List<GuitarColorDTO>> GetAllGuitarColors();
        Task CreateGuitarColor(GuitarColorDTO guitarColorDTO);
        Task DeleteGuitarColor(GuitarColorDTO guitarColorDTO);
        Task UpdateGuitarColor(GuitarColorDTO guitarColorDTO);
    }
}
