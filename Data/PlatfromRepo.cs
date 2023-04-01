using PlatformService.Data.Repos;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatfromRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;
        public PlatfromRepo(AppDbContext context)
        {
            _context = context; 
        }
        public void CreateaPlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
            _context.SaveChanges();
            
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            var res = _context.Platforms.FirstOrDefault(p => p.Id == id); 
            if (res == null)
            {
                throw new NullReferenceException($"{nameof(res)} doesnt' exist ");
            }
            return res;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
