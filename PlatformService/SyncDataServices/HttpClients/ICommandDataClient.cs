using PlatformService.DTOs;

namespace PlatformService.SyncDataServices.HttpClients
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommandService(PlatfromReadDTO data);
    }
}
