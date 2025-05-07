using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IWoodsTypeService
    {
        Task<List<WoodsTypeDTO>> GetAllWoodsTypes();
        Task CreateWoodsType(WoodsTypeDTO woodsTypeDTo);
        Task DeletWoodsType(WoodsTypeDTO woodsTypeDTo);
        Task UpdateWoodsType(WoodsTypeDTO woodsTypeDTo);
    }
}
