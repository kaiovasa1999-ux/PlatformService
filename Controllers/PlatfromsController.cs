using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Repos;
using PlatformService.DTOs;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatfromsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatfromsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatfromReadDTO>> GetPlatfroms()
        {
            var platfromItems = _platformRepo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatfromReadDTO>>(platfromItems));
        }

        [HttpGet("{id}")]
        public ActionResult<PlatfromReadDTO> GetplafromById(int id)
        {
            var platfrom = _platformRepo.GetPlatformById(id);

            if(platfrom == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PlatfromReadDTO>(platfrom));
        }

    }
}
