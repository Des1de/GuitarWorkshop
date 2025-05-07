using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IFretNumberTypeService
    {
        Task<List<FretNumberTypeDTO>> GetAllFretNumberTypes();
        Task CreateFretNumberType(FretNumberTypeDTO fretNumberTypeDTO);
        Task DeleteFretNumberType(FretNumberTypeDTO fretNumberTypeDTO);
        Task UpdateFretNumberType(FretNumberTypeDTO fretNumberTypeDTO);
    }
}
