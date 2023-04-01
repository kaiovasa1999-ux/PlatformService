using PlatformService.Models;

namespace PlatformService.Data.Repos
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();

        Platform GetPlatformById(int id);

        void CreateaPlatform(Platform platform);
    }
}
