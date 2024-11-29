using BankingApplication.Data;
using BankingApplication.Models.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankingApplication.Models;

namespace BankingApplication.Controllers
{
    [Route("[Controller]")]
    public class AuthController : Controller
    {

        private readonly BankingApplicationContext _context;

      
        AuthController(BankingApplicationContext context)
        {
            _context=context;
        }

        [HttpGet("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Signin()
        {
            return View();
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> PostSignin(SigninViewDTO RequestParameter)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _context.Users.FirstOrDefaultAsync(u => u.userName == RequestParameter.username && u.password == RequestParameter.password);

                    if (user != null)
                    {
                        user.password = "";
                        //generate JWT Token
                        return RedirectToAction(nameof(UserDashboard), new { UserId = user.userId });
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "No Such User Found!!";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ViewData["ErrorMessage"] = "Invalid Login Credentials";
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid Login Credentials";
            }

            return View("Signin", RequestParameter);
        }

        [HttpGet("dashboard")]
        [Authorize]

        public async Task<IActionResult> UserDashboard(int UserId)
        {
            if (UserId!=0)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u=>u.userId==UserId);

                return View(user);
            }
            else
            {
                //show a custom error page 
                ViewData["ErrorMessage"] = "Invalid user to show Dashboard";
                return View("Signin", new SigninViewDTO());
            }
        }
    }
}
