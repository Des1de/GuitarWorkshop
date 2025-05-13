using GuitarWorkshopUI.DTO;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IGuitarBuildService
    {
        Task<List<GuitarBuildDTO>> GetGuitarBuildsByUserId(int userId);
        Task<List<GuitarBuildDTO>> GetAllGuitarBuilds();
        Task<GuitarBuildDTO> GetGuitarBuild(int buildId);
        Task CreateGuitarBuild(CreateGuitarBuildDTO guitarBuildDTO);
        Task DeleteGuitarBuild(GuitarBuildDTO guitarBuildDTO);
        Task UpdateGuitarBuild(GuitarBuildDTO guitarBuildDTO);
    }
}
