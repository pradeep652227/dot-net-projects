using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoAppWebAPI.Models.DTO;
using MongoAppWebAPI.Models;
using MongoAppWebAPI.Services.Abstraction;

namespace MongoAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _iUow;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IUnitOfWork iUoW, ILogger<MovieController> logger)
        {
            _iUow = iUoW;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddMovieAsync(MovieModel Movie)
        {
            try
            {
                _iUow.iMovieRepository.AddMovieAsync(Movie);
                return Ok();
            }
            catch (Exception ex) 
            {
                throw new Exception("Internal Server Error at AddMovieAsync-MovieController", ex);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetMovieAsync(string MovieId)
        {
            try
            {
                _logger.LogInformation("This is Log Information");

                _logger.LogWarning("This is a warning log.");
                var Movie=await _iUow.iMovieRepository.GetMovieAsync(MovieId);

                if (Movie == null) 
                    return NotFound();
                return Ok(Movie);
            }
            catch (Exception ex)
            {
                _logger.LogError("This is an error log.");
                throw new Exception("Internal Server Error at GetMovieAsync-MovieController", ex);
            }

        }
    }
}
