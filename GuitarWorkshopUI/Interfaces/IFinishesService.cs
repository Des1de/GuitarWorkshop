using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IFinishesService
    {
        Task<List<FinishDTO>> GetAllFinishes();
        Task CreateFinish(FinishDTO finishDTO);
        Task DeleteFinish(FinishDTO finishDTO);
        Task UpdateFinish(FinishDTO finishDTO);
    }
}
