using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecretController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "This is a secured endpoint" });
        }

    }
}
