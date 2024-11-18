using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvCProj_1.Data;
using MvCProj_1.Models;
namespace MvCProj_1.Controllers
{
    public class JobPostsController : Controller
    {
        private readonly MvCProj_1Context _context;

        public JobPostsController(MvCProj_1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //fetch all job posts
            var jobs = _context.JobPosts.ToList();
            ViewBag.testing = "i'm testing this string ";
            return View(jobs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobPostsModel newJob)
        {
            if (ModelState.IsValid)
            {
                _context.JobPosts.Add(newJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(newJob);
        }

        public async Task<IActionResult> Job([FromRoute] int Id)
        {
            var job = await _context.JobPosts.FirstOrDefaultAsync(x => x.Id == Id);
            if (job == null)
                return NotFound();

            return View(job);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var job = await _context.JobPosts.FirstOrDefaultAsync(x => x.Id == id);
            //send the Job model to create view 
            if (job == null)
                return NotFound();

            return View("~/Views/JobPosts/Create.cshtml", job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobPostsModel job)
        {
            if (ModelState.IsValid)
            {
                if (job == null)
                    return BadRequest("job object is null");

                _context.JobPosts.Update(job);
               await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View("Create",job);
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var job= await _context.JobPosts.FirstOrDefaultAsync(y => y.Id == id);
                if (job == null)
                    return BadRequest("No Such Job Exists");

                _context.JobPosts.Remove(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest("Error in Deleting Job");
            }
        }
    }
}