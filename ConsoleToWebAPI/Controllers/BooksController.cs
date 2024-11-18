using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsoleToWebAPI.Controllers

{    [ApiController]
    [Route("api/[controller]")]
    
    public class BooksController : ControllerBase
    {
        [Route("{id:int:min(10)}")]
        [HttpGet]
        public string Get(int id)
        {
            return "Output is"+id;
        }
        
    }
}
