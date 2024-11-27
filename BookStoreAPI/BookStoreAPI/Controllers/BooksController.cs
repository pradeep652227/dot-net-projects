using BookStoreAPI.Models;
using BookStoreAPI.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;//field declaration
        public BooksController(IBookRepository bookRepo)//Book controller instantiated
        {
            _bookRepo = bookRepo;//_bookRepo will now hold a reference to BooKRepository class 
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookRepo.GetAllBooksAsync();

                return Ok(books);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] int Id)
        {
            var record = await _bookRepo.GetBookByIdAsync(Id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        // POST: api/books
        [HttpPost("")]
        public async Task<IActionResult> AddBookAsync([FromBody] BookModel bookModel)
        {
            if (bookModel == null)
            {
                return BadRequest();
            }

            var bookId = await _bookRepo.AddBookAsync(bookModel);
            return Created("~/api/books/" + bookId, bookId);
            //return CreatedAtAction(nameof(GetBookByIdAsync), new { Id = bookId, }, bookId);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute]int Id,[FromBody]BookModel bookModel)
        {
            bool isUpdateDone=await _bookRepo.UpdateBookAsync(Id, bookModel);

            if (isUpdateDone)
                return Ok("Record updated Successfully!!");
            return Accepted();

        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateBookPatchAsync([FromRoute]int Id, [FromBody] JsonPatchDocument bookModel)
        {
            var isUpdateDone =await _bookRepo.UpdateBookPatchAsync(Id, bookModel);
            if (isUpdateDone)
                return Ok("Updated");
            return Accepted();  
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute]int Id)
        {
            var isDeleteDone = await _bookRepo.DeleteBookAsync(Id);
            if (isDeleteDone)
                return Ok("Book Successfully Removed from DB");
        return Accepted();
        }
    
    }
}
