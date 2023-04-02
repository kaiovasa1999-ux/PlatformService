using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Repos;
using PlatformService.DTOs;
using PlatformService.Models;

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

        [HttpGet("{id}",Name = "GetById")]
        public ActionResult<PlatfromReadDTO> GetplafromById(int id)
        {
            var platfrom = _platformRepo.GetPlatformById(id);

            if(platfrom == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PlatfromReadDTO>(platfrom));
        }

        [HttpPost]
        public ActionResult<PlatfromReadDTO> CreatePlatform(PlatfromCreateDTO platfromCreateDTO)
        {
            var platfromModel = _mapper.Map<Platform>(platfromCreateDTO);
            if(platfromModel != null)
            {
                _platformRepo.CreateaPlatform(platfromModel);
                _platformRepo.SaveChanges();
                var platformReadDTO = _mapper.Map<PlatfromReadDTO>(platfromModel);

                var x = _platformRepo.GetAllPlatforms();

                return CreatedAtRoute(nameof(GetplafromById),new {Id = platformReadDTO.Id}, platformReadDTO);
            }

            return BadRequest();
        }

    }
}
