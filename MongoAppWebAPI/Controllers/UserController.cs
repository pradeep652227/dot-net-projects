using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MongoAppWebAPI.Models;
using MongoAppWebAPI.Services.Abstraction;
using MongoDB.Bson.IO;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _iUoW;
        private readonly IDistributedCache _cache;

        public UserController(IUnitOfWork UoW, IDistributedCache cache)
        {
            _iUoW = UoW;
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserModel User)
        {
            try
            {
                _iUoW.iUserRepository.AddUserAsync(User);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at AddUserAsync - UserController", ex);
            }

        }


        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserAsync([FromRoute] string UserId)
        {
            try
            {
                var user = await _iUoW.iUserRepository.GetUserAsync(UserId);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at GetUserAsync - UserController", ex);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var cachedUsers = await _cache.GetStringAsync("cachedUsers");
                if (!string.IsNullOrEmpty(cachedUsers))
                {
                    return Ok(JsonSerializer.Deserialize<List<UserModel>>(cachedUsers));

                }
                else
                {
                    var users = await _iUoW.iUserRepository.GetUsersAsync();
                    if (users == null || users.Count == 0)
                        return NotFound();
                    //cache the users
                    await _cache.SetStringAsync("cachedUsers", JsonSerializer.Serialize(users), new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)  // Cache expiration time
                    });

                    return Ok(users);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at GetAllUsersAsync - UserController", ex);
            }

        }


        [HttpPut("{UserId}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] string UserId, [FromBody] Dictionary<string, object> User)
        {
            try
            {
                var res = await _iUoW.iUserRepository.UpdateUserModelAsync(UserId, User);
                if (res.isSuccess)
                    return Ok(res);

                return BadRequest(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at UpdateUserAsync - UserController", ex);
            }

        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string UserId)
        {
            try
            {
                var res = await _iUoW.iUserRepository.DeleteUserAsync(UserId);
                if (res.isSuccess)
                    return Ok(res);

                return BadRequest(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at DeleteUserAsync - UserController", ex);
            }

        }

        [HttpGet("{UserId}/playlists")]
        public async Task<IActionResult> GetPlaylistsForUserAsync([FromRoute] string UserId)
        {
            try
            {
                var res = await _iUoW.iUserRepository.GetPlaylistsForUser(UserId);
                if (res == null || res.Count == 0)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at GetPlaylistsForUserAsync - UserController", ex);

            }
        }

        [HttpGet("{UserId}/user-playlists")]
        public async Task<IActionResult> GetUserWithPlaylistsDataAsync([FromRoute] string UserId)
        {
            try
            {
                var res = await _iUoW.iUserRepository.GetUserWithPlaylistsDataAsync(UserId);
                if (res == null || res.Count == 0)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at GetUserWithPlaylistsDataAsync - UserController", ex);

            }
        }

        [HttpGet("{UserId}/user-playlists-movies")]
        public async Task<IActionResult> GetUserWithPlaylistWithMovieAsync([FromRoute] string UserId)
        {
            try
            {
                if (string.IsNullOrEmpty(UserId))
                    return BadRequest("Kindly input correct UserId format");

                var res = await _iUoW.iUserRepository.GetUserWithPlaylistWithMovieAsync(UserId);
                if (res == null || res.Count == 0)
                {
                    return NotFound();
                }
                return Ok(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at GetUserWithPlaylistWithMovieAsync - UserController", ex);

            }
        }

        [HttpPost("post-user1")]
        public async Task<IActionResult> AddUser1Async([FromBody] UserModel1 User)
        {
            try
            {
                _iUoW.iUserRepository.AddUser1Async(User);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at AddUser1Async - UserController", ex);
            }

        }


        [HttpGet("{UserId}/usermodel1")]
        public async Task<IActionResult> GetUserModel1(string UserId)
        {
            try
            {

                return Ok(await _iUoW.iUserRepository.GetUserModel1Async(UserId));

            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at GetUserWithPlaylistWithMovieAsync1 - UserController", ex);
            }
        }

        [HttpGet("{UserId}/user-playlists-movies-2")]
        public async Task<IActionResult> GetUserWithPlaylistWithMovieAsync2([FromRoute] string UserId)
        {
            try
            {
                if (string.IsNullOrEmpty(UserId))
                    return BadRequest("Kindly input correct UserId format");

                var res = await _iUoW.iUserRepository.GetUserWithPlaylistWithMovieAsync2(UserId);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at GetUserWithPlaylistWithMovieAsync1 - UserController", ex);

            }
        }
        [HttpGet("{UserId}/user-playlists-movies-1")]
        public async Task<IActionResult> GetUserWithPlaylistWithMovieAsync1([FromRoute] string UserId)
        {
            try
            {
                if (string.IsNullOrEmpty(UserId))
                    return BadRequest("Kindly input correct UserId format");

                var res = await _iUoW.iUserRepository.GetUserWithPlaylistWithMovieAsync1(UserId);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error at GetUserWithPlaylistWithMovieAsync1 - UserController", ex);

            }
        }
    }
}
