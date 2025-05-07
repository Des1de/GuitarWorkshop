using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IStringTypeService
    {
        Task<List<StringTypeDTO>> GetAllStringTypes();
        Task CreateStringType(StringTypeDTO stringTypeDTO);
        Task DeletStringType(StringTypeDTO stringTypeDTO);
        Task UpdateStringType(StringTypeDTO stringTypeDTO);
    }
}
