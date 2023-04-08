using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformServiceController : ControllerBase
    {
        public PlatformServiceController()
        {
            
        }

        [HttpPost]
        public ActionResult TestConnection()
        {
            Console.WriteLine("connecting is done!");
            return Ok("Was Okey!");
        }
    }
}
