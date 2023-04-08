using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Repos;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.SyncDataServices.HttpClients;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatfromsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatfromsController(
            IPlatformRepo platformRepo, 
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
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
        public async Task<ActionResult<PlatfromReadDTO>> CreatePlatform(PlatfromCreateDTO platfromCreateDTO)
        {
            var platfromModel = _mapper.Map<Platform>(platfromCreateDTO);
            if(platfromModel != null)
            {
                _platformRepo.CreateaPlatform(platfromModel);
                _platformRepo.SaveChanges();
                var platformReadDTO = _mapper.Map<PlatfromReadDTO>(platfromModel);

                try
                {
                    await _commandDataClient.SendPlatformToCommandService(platformReadDTO);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync($"Occur a problem while createing the platfomr!!!{ex.Message}");
                }

                return CreatedAtRoute(nameof(GetplafromById),new {Id = platformReadDTO.Id}, platformReadDTO);
            }

            return BadRequest();
        }

    }
}
