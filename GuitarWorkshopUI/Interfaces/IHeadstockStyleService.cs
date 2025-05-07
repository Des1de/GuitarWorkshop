using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IHeadstockStyleService
    {
        Task<List<HeadstockStyleDTO>> GetAllHeadstockStyles();
        Task CreateHeadstockStyle(HeadstockStyleDTO headstockStyleDTO);
        Task DeleteHeadstockStyle(HeadstockStyleDTO headstockStyleDTO);
        Task UpdateHeadstockStyle(HeadstockStyleDTO headstockStyleDTO);
    }
}
