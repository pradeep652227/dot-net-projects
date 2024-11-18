using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [ApiController]
    [Route("api")]
   
    public class TestController : ControllerBase
    {
        [Route("test")]
        [HttpGet]
        public string Get()
        {
            return "Hello From  Get";
        }

    }
}
