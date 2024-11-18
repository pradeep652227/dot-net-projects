using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BindProperties]
    public class StatusCodesController : ControllerBase
    {

        [Route("1",Name="FirstRoute")]
        [HttpGet]
        public IActionResult GetDetails1()
        {
            return Ok("Hello");
        }

        [Route("{id}")]
        [HttpGet]
        public string GetDetails2(int id)
        {
            return "Hello "+id;
        }

            [HttpPost("3",Name ="PostRoute")]
            public IActionResult PostDetails(AnimalModel animal)
            {
                animal.Id = 5;
            //return Created("/api/statuscodes/1", animal);
            return CreatedAtRoute("FirstRoute", animal);
                //return CreatedAtAction("GetDetails2", new { id = 2 },new {id=2,name="Hello"});

            }

        }

        public class AnimalModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
