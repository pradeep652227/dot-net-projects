using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvCProj_1.Context;
using MvCProj_1.Data;
using MvCProj_1.Helpers;
using MvCProj_1.Models.Authentication;
using System.Data;

namespace MvCProj_1.Controllers
{
    public class UserController : Controller
    {
        private readonly MvCProj_1Context _context;
        public IConfiguration _config;

        private readonly DBContext _dbContext;
        
        public UserController(MvCProj_1Context context,IConfiguration config,DBContext dbContext)
        {
            _context= context;
            _config = config;
            _dbContext= dbContext;
        }
        //[AllowAnonymous]
        [Authorize]
        public async Task<IActionResult> Index(int id)
        {
            var token = HttpContext.Request.Cookies["jwtToken"];

            var foundUser=await _context.Users.FirstOrDefaultAsync(u=>u.Id==id);
            if (foundUser != null)
                return View(foundUser);

            else
                return NotFound();
        }

        [Authorize]
        public async Task<IActionResult> HiddenRoute()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var data = (await connection.QueryAsync<object>("sp_getEmployeesDetails",
                                                              param: new
                                                              {
                                                                  EmpIdRangeStart = 100,
                                                                  EmpIdRangeEnd = 110
                                                              },
                                                              commandType: CommandType.StoredProcedure));
                if (data!=null)
                    return View();
                ViewData["data"] = data;
                return RedirectToAction("Index","Home");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] UserRegisterModel userObj)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    FirstName = userObj.FirstName,
                    LastName = userObj.LastName,
                    Email = userObj.Email,
                    Password = userObj.Password
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                var token = GenerateToken.GenerateJwtToken(user.FirstName, _config);
                //var token = new GenerateToken().GenerateJwtToken(user.FirstName, _config);
                HttpContext.Response.Cookies.Append("jwtToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Ensure this is set in production with HTTPS
                });
                return RedirectToAction(nameof(Index),new { id = user.Id });
            }
            return BadRequest();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]              
        public IActionResult Login([FromForm] UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                var foundUser=_context.Users.FirstOrDefault(u=>u.Email== user.Email && u.Password==user.Password);
                if (foundUser != null)
                {
                    var token = GenerateToken.GenerateJwtToken(foundUser.FirstName, _config);
                    //var token = new GenerateToken().GenerateJwtToken(user.FirstName, _config);
                    //HttpContext.Response.Cookies.Append("jwtToken", token, new CookieOptions
                    //{
                    //    HttpOnly = true,
                    //    Secure = true, // Ensure this is set in production with HTTPS
                    //});
                    Response.Cookies.Append("jwtToken", token); // Store token in cookie for authorization
                    return RedirectToAction(nameof(Index), new { id = foundUser.Id });
                }
                return NotFound();

            }
            return Unauthorized();
        }


        public IActionResult logout()
        {
            Response.Cookies.Delete("jwtToken");
           return  RedirectToAction("Index","Home");
        }
        public string getToken()
        {
            return GenerateToken.GenerateJwtToken("test", _config);
        }
    }

}
/**/
