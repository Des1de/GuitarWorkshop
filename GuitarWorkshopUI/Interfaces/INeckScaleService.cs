using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface INeckScaleService
    {
        Task<List<NeckScaleDTO>> GetAllNeckScales();
        Task CreateNeckScale(NeckScaleDTO neckScaleDTO);
        Task DeletNeckScale(NeckScaleDTO neckScaleDTO);
        Task UpdateNeckScale(NeckScaleDTO neckScaleDTO);
    }
}
