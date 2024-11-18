using Microsoft.AspNetCore.Mvc;
using ConsoleToWebAPI.Models;
using ConsoleToWebAPI.Binders;
namespace ConsoleToWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    public class BindingController:ControllerBase
    {

        public CountryModel Country { get; set; }


        [HttpPost("{id}")]
        public IActionResult AddCountry([FromQuery]int id)
        {
            return Ok(id+" ");
        }

        [HttpGet("search")]

        public IActionResult SearchCountries([ModelBinder(typeof(CustomBinder))] string[] countries)
        {
            return Ok(countries);
        }

    }
}
