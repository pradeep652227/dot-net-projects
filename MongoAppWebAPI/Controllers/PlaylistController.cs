using Microsoft.AspNetCore.Mvc;
using MongoAppWebAPI.Context;
using MongoAppWebAPI.Models;
using MongoAppWebAPI.Models.DTO;
using MongoAppWebAPI.Services.Abstraction;

namespace MongoAppWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IUnitOfWork _iUow;

        public PlaylistController(IUnitOfWork iUoW)
        {
            _iUow = iUoW;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlaylistModel playlist)
        {
            ResultDTO result = await _iUow.iPlaylistRepository.CreatePlaylistAsync(playlist);

            if (result.isSuccess)
                return Ok(result);
            return StatusCode(StatusCodes.Status500InternalServerError, "Exception Occured Contact Admin");
        }

        [HttpPost("add-playlist1")]
        public async Task<IActionResult> CreatePlaylistAsync1(PlaylistModel1 playlist)
        {
            ResultDTO result = await _iUow.iPlaylistRepository.CreatePlaylistAsync1(playlist);

            if (result.isSuccess)
                return Ok(result);
            return StatusCode(StatusCodes.Status500InternalServerError, "Exception Occured Contact Admin");
        }
        //Read
        [HttpGet]
        public async Task<IActionResult> GetPlaylistModel(string Id)
        {
            try
            {
                var playlist = await _iUow.iPlaylistRepository.GetPlaylistModelAsync(Id);
                if (playlist == null)
                {
                    return NotFound();
                }
                return Ok(playlist);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error", ex);
            }
        }

        [HttpPatch]
        public async Task<ResultDTO> UpdatePlaylistAsync(string Id, string oldItem, string newItem)
        {
            try
            {
                var res = await _iUow.iPlaylistRepository.UpdatePlaylistAsync(Id, oldItem, newItem);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error", ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlaylist([FromBody] PlaylistModel updatedPlaylist)
        {
            if (string.IsNullOrEmpty(updatedPlaylist.Id))
            {
                return BadRequest("Playlist ID is required");
            }

            var result = await _iUow.iPlaylistRepository.UpdatePlaylistModelAsync(updatedPlaylist.Id, updatedPlaylist);

            if (result.isSuccess)
            {
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlaylist([FromBody] string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return BadRequest("Playlist ID is required");
                }

                var res = await _iUow.iPlaylistRepository.DeletePlaylistAsync(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error", ex);
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetPlaylistWithMoviesAsync(string PlaylistId)
        //{
        //    try
        //    {
        //        var res = await _iUow.iPlaylistRepository.GetPlaylistWithMoviesAsync(PlaylistId);
        //        if (res == null)
        //            return NotFound();
        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Internal Server Error", ex);

        //    }


        //}
    }
}
