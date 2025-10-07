namespace API.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PingController : ControllerBase
    {


        [HttpGet("pong")]
        public IActionResult Pong()
        {
            return Ok("ping-pong");
        }
    }
}
