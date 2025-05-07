using GuitarWorkshopUI.DTO.GuitarParts;

namespace GuitarWorkshopUI.Interfaces
{
    public interface ITuningMachineService
    {
        Task<List<TuningMachineDTO>> GetAllTuningMachines();
        Task CreateTuningMachine(TuningMachineDTO tuningMachineDTO);
        Task DeletTuningMachine(TuningMachineDTO tuningMachineDTO);
        Task UpdateTuningMachine(TuningMachineDTO tuningMachineDTO);
    }
}
